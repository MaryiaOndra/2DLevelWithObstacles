using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleJumpState : BaseState
{
    [SerializeField]
    float jumpForce;

    float lowYVelosity = -3.0f;

    public override PlayerState PlayerState => PlayerState.AngleJump;

    private void FixedUpdate()
    {

        var _velocity = rBody2D.velocity;

        float _jumpValue = Input.GetAxis("Jump");

        if (_jumpValue > 0)
        {
            if (IsNearLeftWall)
            {
                _velocity = Vector2.one * jumpForce;
                playerSprite.flipX = false;
            }
            else if (IsNearRightWall)
            {
                _velocity.x = Vector2.one.x * jumpForce * -1;
                _velocity.y = Vector2.one.y * jumpForce;
                playerSprite.flipX = true;
            }
        }

        rBody2D.velocity = _velocity;

        if (_velocity.y < lowYVelosity)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
    }
}
