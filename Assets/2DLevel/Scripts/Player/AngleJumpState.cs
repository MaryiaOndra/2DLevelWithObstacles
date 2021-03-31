using UnityEngine;

public class AngleJumpState : BaseState
{
    [SerializeField]
    float jumpForce;

    public override PlayerState PlayerState => PlayerState.AngleJump;

    private void FixedUpdate()
    {
        var _velocity = rBody2D.velocity;

        if (JumpValue > 0)
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
        else if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
    }
}
