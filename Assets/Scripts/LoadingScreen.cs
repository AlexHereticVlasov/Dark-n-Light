using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class LoadingScreen : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Slider _loadBar = default;
    [SerializeField] private TMP_Text _progressText = default;
    [SerializeField] private GameObject _loadingScreen = default;

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
    }

    private void OnStartLoading() => _loadingScreen.SetActive(true);
}