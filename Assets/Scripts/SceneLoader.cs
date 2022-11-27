using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    public event UnityAction StartLoading;
    public event UnityAction<float> Loading;

    private int SceneIndex => SceneManager.GetActiveScene().buildIndex;

    public void LoadScene(int buildIndex) => StartCoroutine(Load(buildIndex));

    public void Restart() => LoadScene(SceneIndex);

    private IEnumerator Load(int buildIndex)
    {
        StartLoading?.Invoke();

        var asyncOperation = SceneManager.LoadSceneAsync(buildIndex);

        while (asyncOperation.isDone == false)
        {
            Loading?.Invoke(asyncOperation.progress);
            yield return null;
        }
    }
}
