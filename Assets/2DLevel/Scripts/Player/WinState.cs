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

        StartCoroutine(GoToNextLevel());
    }

    IEnumerator GoToNextLevel() 
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
