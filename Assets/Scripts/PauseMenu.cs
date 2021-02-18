using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausedScreen;
    [SerializeField] private GameObject UnpausedScreen;

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

        PausedScreen.SetActive(IsPaused);
        UnpausedScreen.SetActive(!IsPaused);
    }
}
