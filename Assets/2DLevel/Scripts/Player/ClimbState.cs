using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : BaseState
{
    [SerializeField]
    float speed;

    public override PlayerState PlayerState => PlayerState.Climb;

    public override void Activate()
    {
        base.Activate();

        rBody2D.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        float _vertical = Input.GetAxis("Vertical");

        var _velocity = rBody2D.velocity;
        _velocity.y += _vertical * speed * Vector2.up.y;

        rBody2D.velocity = _velocity;

        if (IsGrounded)
        {
            NextStateAction.Invoke(PlayerState.Idle);
        }
    }
}
