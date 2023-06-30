using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Zenject;

public sealed class PostProcessingEffects : MonoBehaviour
{
    [Inject] private Lose _lose;
    [SerializeField] private Volume _volume;
    [SerializeField] private TextureCurve _from;
    [SerializeField] private TextureCurve _to;

    private void OnEnable() => _lose.Defeate += OnDefeate;

    private void OnDisable() => _lose.Defeate -= OnDefeate;

    private void OnDefeate()
    {
        if (_volume.profile.TryGet(out ColorCurves colorCurves))
        {
            var tp = colorCurves.hueVsSat;
            StartCoroutine(FadeToGrey(tp));
        }
    }

    private IEnumerator FadeToGrey(TextureCurveParameter parameter)
    {
        _from = parameter.value;

        var t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime;
            t = Mathf.Clamp01(t);
            parameter.Interp(_from, _to, t);
            yield return null;
        }
    }
}
