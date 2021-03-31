using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    public override PlayerState PlayerState => PlayerState.Fall;

    private void FixedUpdate()
    {
        float _jumpValue = Input.GetAxis("Jump");


        if (_jumpValue > 0 && ( IsNearLeftWall || IsNearRightWall )) 
        {
            NextStateAction.Invoke(PlayerState.AngleJump);
        }
        else if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
    }
}
