using System.Collections;
using UnityEngine;

public sealed class Opening : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    
    private string _message = "あなたが種をまくもの、あなたは刈り取るでしょう、罪は贖われることはできません。";

    private void Start() => StartCoroutine(LoadMainScene());

    private IEnumerator LoadMainScene()
    {
        yield return null;
        _loader.LoadScene(1);
    }
}
