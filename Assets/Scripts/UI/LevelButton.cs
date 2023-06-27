using UnityEngine;
using SceneLoad;
using System.Collections;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private BaseFadePanel _fadePanel;

    [field:SerializeField] public int Value { get; private set; }

    public void Load() => StartCoroutine(LoadRoutine(Value + Constants.LevelOffset));

    private IEnumerator LoadRoutine(int sceneIndex)
    {
        _fadePanel.FadeIn();
        yield return new WaitForSeconds(1);
        _loader.LoadScene(sceneIndex);
    }
}
