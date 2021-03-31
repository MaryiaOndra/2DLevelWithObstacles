using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckState : BaseState
{
    [SerializeField]
    Collider2D colliderToHide;

    [SerializeField]
    float speed;

    public override PlayerState PlayerState => PlayerState.Duck;

    public override void Activate()
    {
        base.Activate();

        colliderToHide.enabled = false;
    }

    private void FixedUpdate()
    {
        float _verticalValue = Input.GetAxis("Vertical");
        float _horizontalValue = Input.GetAxis("Horizontal");

        var _velocity = rBody2D.velocity;
        _velocity.x = Vector2.right.x * speed * _horizontalValue;
        rBody2D.velocity = _velocity;

        if (_verticalValue >= 0 && !IsCeilingAbove)
        {
            colliderToHide.enabled = true;
            NextStateAction.Invoke(PlayerState.Idle);
        }
    }
}
