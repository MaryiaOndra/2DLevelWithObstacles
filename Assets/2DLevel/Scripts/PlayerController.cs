using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    Die,
    Fall,
    AngleJump,
    Duck,
    Climb,
    Win
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rBody2D;
    Animator playerAnimator;
    SpriteRenderer sprite;
    List<BaseState> states;
    BaseState currentState;

    private void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

        states.ForEach(_state =>
        {
            _state.Setup(rBody2D, sprite, playerAnimator);
            _state.NextStateAction = OnNextStateRequest;
        });

        currentState = states.Find(_state => _state.PlayerState == PlayerState.Idle);
        currentState.Activate();
    }

    public void OnNextStateRequest(PlayerState _state) 
    {
        currentState.Diactivate();
        currentState = states.Find(_s => _s.PlayerState == _state);
        currentState.Activate();
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentState.OnTrigger(collision);
    }
}
