using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override PlayerState PlayerState => PlayerState.Idle;

    private void FixedUpdate()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _jumpValue = Input.GetAxis("Jump");


        if (_horizontalValue != 0)
        {
            NextStateAction.Invoke(PlayerState.Run);
        }
        else if (_jumpValue != 0)
        {
            NextStateAction.Invoke(PlayerState.Jump);
        }
        else
        {
            var _velocity = rBody2D.velocity;
            _velocity.x = 0;
            rBody2D.velocity = _velocity;
        }
    }
}
    