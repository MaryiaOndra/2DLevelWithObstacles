using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieState : BaseState
{
    public override PlayerState PlayerState => PlayerState.Die;

    public override void Activate()
    {
        base.Activate();

        playerAnimator.GetBehaviour<PlayerAnimCallback>().DiedAction = OnDied;
    }

    public void OnDied() 
    {
        Debug.Log("Ondied");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
