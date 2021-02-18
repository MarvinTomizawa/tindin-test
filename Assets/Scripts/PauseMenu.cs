using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausedScreen;
    [SerializeField] private GameObject _unpausedScreen;
    [SerializeField] private SceneManagerBehaviour _sceneManagerBehaviour;

    private bool IsPaused = false;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        } 
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;

        Time.timeScale = IsPaused ? 0f : 1f;

        Cursor.visible = IsPaused;

        _pausedScreen.SetActive(IsPaused);
        _unpausedScreen.SetActive(!IsPaused);
    }

    public void GoToTitleScreen()
    {
        Time.timeScale = 1f;
        _sceneManagerBehaviour.LoadTitleScreen();
    }

    public void CloseGame()
    {
        _sceneManagerBehaviour.CloseGame();
    }
}
