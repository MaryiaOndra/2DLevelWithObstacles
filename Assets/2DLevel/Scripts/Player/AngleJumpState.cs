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

        //var _velocity = rBody2D.velocity;

        //if (IsNearLeftWall)
        //{
        //    _velocity = Vector2.one * jumpForce;
        //    playerSprite.flipX = false;
        //}
        //else if (IsNearRightWall)
        //{
        //    _velocity.x = Vector2.one.x * jumpForce * -1;
        //    _velocity.y = Vector2.one.y * jumpForce;
        //    playerSprite.flipX = true;
        //}
        //rBody2D.velocity = _velocity;
    }

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

        if (_velocity.y < 0)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
    }
}
