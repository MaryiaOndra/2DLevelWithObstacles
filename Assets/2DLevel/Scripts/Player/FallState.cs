
public class FallState : BaseState
{
    public override PlayerState PlayerState => PlayerState.Fall;

    private void FixedUpdate()
    {
        if (JumpValue > 0 && ( IsNearLeftWall || IsNearRightWall )) 
        {
            NextStateAction.Invoke(PlayerState.AngleJump);
        }
        else if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
    }
}
