using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private bool _startWithTransition;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private float transitionSpeed = 2f;

    private void Awake()
    {
        if (_startWithTransition)
        {
            _loadingScreen.SetActive(true);
            _animator.SetTrigger("FadeOut");
        }
    }

    public void LoadTitleScreen()
    {
        LoadSceneWithLoading("TitleScreen");
    }

    public void StartGame()
    {
        LoadSceneWithLoading("Game");
    }

    private void LoadSceneWithLoading(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        _loadingScreen.SetActive(true);

        _animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(transitionSpeed);

        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
