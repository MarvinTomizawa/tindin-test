using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
