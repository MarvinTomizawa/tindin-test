using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private bool _startWithTransition;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_startWithTransition)
        {
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
        Time.timeScale = 1f;
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        _animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        var operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = progress;
            yield return null;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
