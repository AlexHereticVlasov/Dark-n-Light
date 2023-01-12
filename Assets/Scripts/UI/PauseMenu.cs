using UnityEngine;
using Zenject;

public sealed class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    [Inject] private SceneLoader _loader;

    public void PauseGame()
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        _panel.SetActive(false);
    }

    public void LoadMap()
    {
        Time.timeScale = 1;
        _loader.LoadScene(Constants.MapSceneIndex);
    }

    public void GoToMain()
    {
        Time.timeScale = 1;
        _loader.LoadScene(Constants.MainMenuIndex);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        _loader.Restart();
    }

    public void LoadNext()
    { 
        Time.timeScale = 1;
        _loader.LoadNextScene();
    }
}
