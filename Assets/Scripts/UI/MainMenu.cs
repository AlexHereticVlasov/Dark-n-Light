using UnityEngine;
using Zenject;
using SceneLoad;
using System.Collections;

public sealed class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private BaseFadePanel _fadePanel;

    [Inject] private ISceneLoader _loader;

    public void Play(int index) => StartCoroutine(StartPlay(index));

    private IEnumerator StartPlay(int index)
    {
        _fadePanel.FadeIn();
        yield return new WaitForSeconds(1);
        _loader.LoadScene(index);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        foreach (var panel in _panels)
            panel.SetActive(panel == panelToShow);
    }

    public void Quit() => Application.Quit();
}
