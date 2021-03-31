using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : BaseState
{
    [SerializeField]
    float speed;

    public override PlayerState PlayerState => PlayerState.Climb;

    private void FixedUpdate()
    {
        float _vertical = Input.GetAxis("Vertical");
        float _horizontal = Input.GetAxis("Horizontal");

        var _velocity = rBody2D.velocity;


        _velocity.y = _vertical * speed * Vector2.up.y;
        _velocity.x = Vector2.right.x * _horizontal * speed;


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
