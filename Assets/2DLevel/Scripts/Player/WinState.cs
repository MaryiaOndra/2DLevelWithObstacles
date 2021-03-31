using UnityEngine.SceneManagement;

public class WinState : BaseState
{
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
