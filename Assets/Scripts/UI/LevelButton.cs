using UnityEngine;
using SceneLoad;
using System.Collections;
using Zenject;

public sealed class LevelButton : MonoBehaviour
{
    [Inject] private ISceneLoader _loader;
    [SerializeField] private BaseFadePanel _fadePanel; //ToDo: Remove It And Create LevelSelectionFadeMediator

    [field:SerializeField] public int Value { get; private set; }

    public void Load() => StartCoroutine(LoadRoutine(Value + Constants.LevelOffset));

    private IEnumerator LoadRoutine(int sceneIndex)
    {
        _fadePanel.FadeIn();
        yield return new WaitForSeconds(1);
        _loader.LoadScene(sceneIndex);
    }
}
