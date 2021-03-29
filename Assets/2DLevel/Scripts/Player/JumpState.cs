using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float jumpForce = 1;

    public override PlayerState PlayerState => PlayerState.Jump;

    public override void Activate()
    {
        base.Activate();

        var _velocity = rBody2D.velocity;
        _velocity.y += Vector2.up.y * jumpForce;
        rBody2D.velocity = _velocity;
    }

    private void FixedUpdate()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        var _velocity = rBody2D.velocity;

        _velocity.x = Vector2.right.x * speed * _horizontalValue;

        if (_velocity.x > 0)
        {
            playerR.flipX = false;
        }
        else if (_velocity.x < 0)
        {
            playerR.flipX = true;
        }

        if (IsGrounded)
        {
            if (_velocity.x == 0)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
        }
        else if (IsNearLeftWall || IsNearRightWall && _velocity.y < 0) 
        {
            NextStateAction.Invoke(PlayerState.AngleJump);
        }
        else
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }

        rBody2D.velocity = _velocity;
    }
}
