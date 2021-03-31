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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
