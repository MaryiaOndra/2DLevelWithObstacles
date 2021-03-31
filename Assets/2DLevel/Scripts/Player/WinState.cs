using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : BaseState
{
    [SerializeField]
    float seconds;

    public override PlayerState PlayerState => PlayerState.Win;

    public override void Activate()
    {
        base.Activate();

        GoToNextLevel();
    }

    void GoToNextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
