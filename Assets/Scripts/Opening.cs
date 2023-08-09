using System.Collections;
using UnityEngine;
using Zenject;
using SceneLoad;

public sealed class Opening : MonoBehaviour
{
    [Inject] private ISceneLoader _loader;
    
    private void Start() => StartCoroutine(LoadMainScene());

    private IEnumerator LoadMainScene()
    {
        yield return null;
        _loader.LoadScene(1);
    }
}
