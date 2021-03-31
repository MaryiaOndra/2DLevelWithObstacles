using UnityEngine;

public class RunState : BaseState
{
    [SerializeField]
    float speed = 2;

    float lowYVelosity = -3.0f;

    public override PlayerState PlayerState => PlayerState.Run;

    private void FixedUpdate()
    {
        var _velocity = rBody2D.velocity;
        _velocity.x = Vector2.right.x * speed * HorizontalValue;
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
            if (JumpValue > 0)
            {
                NextStateAction.Invoke(PlayerState.Jump);
            }
            else if (_velocity.x == 0)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else if (VerticalValue < 0)
            {
                NextStateAction.Invoke(PlayerState.Duck);
            }
        }
        else if (_velocity.y < lowYVelosity)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
        else if(JumpValue > 0)
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }
    }
}
