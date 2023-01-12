using System.Collections;
using UnityEngine;
using Zenject;

public sealed class Opening : MonoBehaviour
{
    [Inject] private SceneLoader _loader;
    
    private void Start() => StartCoroutine(LoadMainScene());

    private IEnumerator LoadMainScene()
    {
        yield return null;
        _loader.LoadScene(1);
    }
}
