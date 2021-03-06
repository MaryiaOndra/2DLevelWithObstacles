﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    static readonly int INT_STATE = Animator.StringToHash("State");
   
    protected SpriteRenderer playerSprite;
    protected Rigidbody2D rBody2D;
    protected Animator playerAnimator;

    protected List<Collider2D> collider2Ds;
    protected ContactFilter2D groundFilter2D;
    protected ContactFilter2D wallsFilterLeft2D;
    protected ContactFilter2D wallsFilterRight2D;

    #region Properties
    public abstract PlayerState PlayerState { get; }
    public Action<PlayerState> NextStateAction { get; set; }

    protected float HorizontalValue 
    {
        get 
        {
            float _horizontalValue = Input.GetAxis("Horizontal");
            return _horizontalValue;
        }    
    }

    protected float VerticalValue
    {
        get
        {
            float _verticalValue = Input.GetAxis("Vertical");
            return _verticalValue;
        }
    }

    protected float JumpValue 
    {
        get
        {
            float _jumpValue = Input.GetAxis("Jump");
            return _jumpValue;
        }
    }

    protected bool IsGrounded
    {
        get
        {
            bool _value = false;
            int _counts = rBody2D.GetContacts(groundFilter2D, collider2Ds);
            _value = _counts > 0;
            return _value;
        }
    }

    protected bool IsNearRightWall
    {
        get
        {
            bool _value = false;
            int _counts = rBody2D.GetContacts(wallsFilterRight2D, collider2Ds);
            _value = _counts > 0;
            return _value;
        }
    }

    protected bool IsNearLeftWall
    {
        get
        {
            bool _value = false;
            int _counts = rBody2D.GetContacts(wallsFilterLeft2D, collider2Ds);
            _value = _counts > 0;
            return _value;
        }
    }

    protected bool IsCeilingAbove
    {
        get
        {
            bool _value = false;
            float _dist = 1.5f;
            int _layerMask = LayerMask.GetMask("Platform");

            RaycastHit2D _hitCheck = Physics2D.Raycast(transform.position, Vector2.up, _dist, _layerMask);

            if (_hitCheck.collider == null)
                _value = false;
            else
                _value = true;

            return _value;
        }
    }

    #endregion

    public void Setup(Rigidbody2D _rBody2D, SpriteRenderer _playerR, Animator _playerAnimator) 
    {
        playerSprite = _playerR;
        rBody2D = _rBody2D;
        playerAnimator = _playerAnimator;
        collider2Ds = new List<Collider2D>();
        SetGroundWallFilters();
    }

    public virtual void Activate() 
    {
        gameObject.SetActive(true);
        playerAnimator.SetInteger(INT_STATE, (int)PlayerState);
    }

    public virtual void Diactivate() 
    {
        gameObject.SetActive(false);
    }

    public virtual void OnCollision(Collision2D collision)
    {
        if (collision.transform.tag == "Poison" || collision.transform.tag == "Enemy")
        {
            NextStateAction.Invoke(PlayerState.Die);
        }
    }

    public virtual void OnTrigger(Collider2D collision)
    {
        if (collision.tag == "HappyEnd")
        {
            NextStateAction.Invoke(PlayerState.Win);
        }
        else if (collision.tag == "Stair")
        {
            NextStateAction.Invoke(PlayerState.Climb);
        }
    }

    void SetGroundWallFilters() 
    {
        groundFilter2D = new ContactFilter2D();
        groundFilter2D.SetNormalAngle(89, 91);
        groundFilter2D.useNormalAngle = true;

        wallsFilterLeft2D = new ContactFilter2D();
        wallsFilterLeft2D.SetNormalAngle(-1, 1);
        wallsFilterLeft2D.useNormalAngle = true;

        wallsFilterRight2D = new ContactFilter2D();
        wallsFilterRight2D.SetNormalAngle(179, 181);
        wallsFilterRight2D.useNormalAngle = true;
    }
}
