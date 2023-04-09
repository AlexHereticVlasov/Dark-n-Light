using UnityEngine;
using Zenject;
using SceneLoad;


public sealed class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    
    [Inject] private SceneLoader _loader;

    //Hack:TempSolution
    public void Play() => _loader.LoadScene(Constants.MapSceneIndex);

    public void ShowPanel(GameObject panelToShow)
    {
        foreach (var panel in _panels)
            panel.SetActive(panel == panelToShow);
    }

    public void Quit() => Application.Quit();
}
