using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    [SerializeField]
    float speed = 2;

    public override PlayerState PlayerState => PlayerState.Run;

    private void FixedUpdate()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _jumpValue = Input.GetAxis("Jump");

        var _velocity = rBody2D.velocity;
         _velocity.x = Vector2.right.x * speed * _horizontalValue;
        rBody2D.velocity = _velocity;

        if (_velocity.x > 0)
        {
            playerSprite.flipX = false;
        }
        else if (_velocity.x < 0)
        {
            playerSprite.flipX = true;
        }

        if (IsGrounded)
        {
            if (_jumpValue > 0)
            {
                NextStateAction.Invoke(PlayerState.Jump);
            }
            else if (_velocity.x == 0)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
        else if (_velocity.y < 0)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
        else
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }
    }
}
