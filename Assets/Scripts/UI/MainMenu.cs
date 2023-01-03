using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private SceneLoader _loader;

    //Hack:TempSolution
    public void Play() => _loader.LoadScene(2);

    public void ShowPanel(GameObject panelToShow)
    {
        foreach (var panel in _panels)
            panel.SetActive(panel == panelToShow);
    }

    public void Quit() => Application.Quit();
}
