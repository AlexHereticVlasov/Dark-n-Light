using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class GhostPlatform : Platform
{
    [SerializeField] private float _rate;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private UnityEngine.Rendering.Universal.ShadowCaster2D _shadowCaster;

    private WaitForSeconds _delay;

    public event UnityAction<float> TransperacyChanged;

    private IEnumerator Start()
    {
        _delay = new WaitForSeconds(_rate);

        while (true)
        {
            yield return FadeIn();
            yield return FadeOut();
        }
    }

    private IEnumerator FadeIn()
    {
        _shadowCaster.enabled = false;

        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            TransperacyChanged?.Invoke(1 - factor);
            yield return null;
        }

        _collider.enabled = false;

        yield return _delay;
    }

    private IEnumerator FadeOut()
    {

        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            TransperacyChanged?.Invoke(factor);
            yield return null;
        }

        _collider.enabled = true;
        _shadowCaster.enabled = true;

        yield return _delay;
    }
}
