
public class IdleState : BaseState
{
    public override PlayerState PlayerState => PlayerState.Idle;

    private void FixedUpdate()
    {
        if (HorizontalValue != 0)
        {
            NextStateAction.Invoke(PlayerState.Run);
        }
        else if (JumpValue != 0)
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }
        else if (VerticalValue < 0)
        {
            NextStateAction.Invoke(PlayerState.Duck);
        }
        else
        {
            var _velocity = rBody2D.velocity;
            _velocity.x = 0;
            rBody2D.velocity = _velocity;
        }
    }
}
    