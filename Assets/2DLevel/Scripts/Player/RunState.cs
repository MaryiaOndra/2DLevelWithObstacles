using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    [SerializeField]
    float speed = 2;

    float lowYVelosity = -3.0f;

    public override PlayerState PlayerState => PlayerState.Run;

    private void FixedUpdate()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _verticalValue = Input.GetAxis("Vertical");
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
            else if (_verticalValue < 0)
            {
                NextStateAction.Invoke(PlayerState.Duck);
            }
        }
        else if (_velocity.y < lowYVelosity)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
        else if(_jumpValue > 0)
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }

    }
}
