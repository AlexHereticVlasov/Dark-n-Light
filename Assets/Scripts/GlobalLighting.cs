using System.Collections;
using UnityEngine;


public interface IGlobalLighting
{
    void FadeIn();
    void FadeOut();
}

public sealed class GlobalLighting : MonoBehaviour, IGlobalLighting
{
    private const float FadeSpeed = 0.3f;

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _globalLight;

    private Coroutine _fadeRoutine;

    public void FadeIn()
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);

        _fadeRoutine = StartCoroutine(FadeInRoutine());
    }

    public void FadeOut()
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);

        _fadeRoutine = StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        while (_globalLight.intensity > 0)
        {
            _globalLight.intensity -= Time.deltaTime * FadeSpeed;
            yield return null;
        }

        _fadeRoutine = null;
    }

    private IEnumerator FadeOutRoutine()
    {
        while (_globalLight.intensity < .3f)
        {
            _globalLight.intensity += Time.deltaTime * FadeSpeed;
            yield return null;
        }

        _fadeRoutine = null;
    }
}
