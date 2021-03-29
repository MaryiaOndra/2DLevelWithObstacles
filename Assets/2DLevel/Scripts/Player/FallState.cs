using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    [SerializeField]
    float speed = 1;

    public override PlayerState PlayerState => PlayerState.Fall;

    private void FixedUpdate()
    {
        float _jumpValue = Input.GetAxis("Jump");
        //float _horizontalValue = Input.GetAxis("Horizontal");

        //var _velocity = rBody2D.velocity;
        //_velocity.x = Vector2.right.x * speed * _horizontalValue;
        //rBody2D.velocity = _velocity;

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
