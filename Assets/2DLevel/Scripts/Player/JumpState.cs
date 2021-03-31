using UnityEngine;

public class JumpState : BaseState
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;

    float lowYVelosity = -5.0f;

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
        var _velocity = rBody2D.velocity;
         _velocity.x = Vector2.right.x * speed * HorizontalValue;

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
            if (_velocity.x == 0)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
        }
        else if (_velocity.y < lowYVelosity)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }

        rBody2D.velocity = _velocity;
    }
}
