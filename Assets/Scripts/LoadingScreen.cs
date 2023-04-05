using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider _loadBar = default;
    [SerializeField] private TMP_Text _progressText = default;
    [SerializeField] private GameObject _loadingScreen = default;

    [Inject] private SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _sceneLoader.StartLoading += OnStartLoading;
        _sceneLoader.Loading += OnLoading;
    }

    private void OnDisable()
    {
        _sceneLoader.StartLoading -= OnStartLoading;
        _sceneLoader.Loading -= OnLoading;
    }

    private void OnLoading(float progress)
    {
        progress = Mathf.Clamp01(progress / 0.9f);                    
        _loadBar.value = progress;
        _progressText.text = $"{ Mathf.RoundToInt(progress * 100)}%"; 
        //ToDo: Create a LoadingScreenPresenter to convert values to simple data end send it to View 
        //ToDo: Create a loading ScreenView class to set this value
    }

    private void OnStartLoading() => _loadingScreen.SetActive(true);
}