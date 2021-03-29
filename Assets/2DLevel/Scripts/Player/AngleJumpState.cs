using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleJumpState : BaseState
{
    [SerializeField]
    float jumpForce;

    public override PlayerState PlayerState => PlayerState.AngleJump;

    public override void Activate()
    {
        base.Activate();

        var _velocity = rBody2D.velocity;

        //if (IsNearLeftWall)
        //{
        //    _velocity = Vector2.one * jumpForce;
        //    playerR.flipX = false;
        //}
        //else if (IsNearRightWall)
        //{
        //    _velocity.x = Vector2.one.x * jumpForce * -1;
        //    _velocity.y = Vector2.one.y * jumpForce;
        //    playerR.flipX = true;
        //}
    }

    private void FixedUpdate()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _jumpValue = Input.GetAxis("Jump");

        var _velocity = rBody2D.velocity;

        if (_velocity.x > 0)
        {
            playerR.flipX = false;
        }
        else if (_velocity.x < 0)
        {
            playerR.flipX = true;
        }

        if (_jumpValue > 0)
        {
            if (IsNearLeftWall)
            {
                _velocity = Vector2.one * jumpForce;
                playerR.flipX = false;
            }
            else if (IsNearRightWall)
            {
                _velocity.x = Vector2.one.x * jumpForce * -1;
                _velocity.y = Vector2.one.y * jumpForce;
                playerR.flipX = true;
            }
        }

        if (_velocity.y < 0)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
        else if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
        //else 
        //{
        //    NextStateAction.Invoke(PlayerState.AngleJump);
        //}


        rBody2D.velocity = _velocity;
    }
}
