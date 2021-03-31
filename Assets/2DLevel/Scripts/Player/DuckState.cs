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

        if (VerticalValue >= 0 && !IsCeilingAbove)
        {
            colliderToHide.enabled = true;
            NextStateAction.Invoke(PlayerState.Run);
        }
    }
}
