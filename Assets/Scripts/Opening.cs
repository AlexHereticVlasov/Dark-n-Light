using System.Collections;
using UnityEngine;

public sealed class Opening : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;

    private void Start() => StartCoroutine(LoadMainScene());

    private IEnumerator LoadMainScene()
    {
        yield return null;
        _loader.LoadScene(1);
    }
}
