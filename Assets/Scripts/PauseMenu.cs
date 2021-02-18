using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausedScreen;
    [SerializeField] private GameObject _unpausedScreen;
    [SerializeField] private GameObject _sceneManagerBehaviour;

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

        _pausedScreen.SetActive(IsPaused);
        _unpausedScreen.SetActive(!IsPaused);
    }
}
