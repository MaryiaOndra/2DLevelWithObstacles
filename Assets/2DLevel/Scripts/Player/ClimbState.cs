using UnityEngine;

public class ClimbState : BaseState
{
    [SerializeField]
    float speed;

    public override PlayerState PlayerState => PlayerState.Climb;

    private void FixedUpdate()
    {
        var _velocity = rBody2D.velocity;
        _velocity.y = VerticalValue * speed * Vector2.up.y;
        _velocity.x = Vector2.right.x * HorizontalValue * speed;
        rBody2D.velocity = _velocity;

        if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
        else if (!IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Fall);
        }
    }
}
