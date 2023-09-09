using System.Collections;
using UnityEngine;


public sealed class DiamondViev : MonoBehaviour, IRecoloreable
{
    private const string CollectedLayerName = "OnCollect";

    [SerializeField] private Diamond _diamond;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private ParticleSystem _star;

    [SerializeField] private ElementBean _elements;

    private void Awake() => Recolor();

    private void OnEnable()
    {
        _diamond.StartCollected += OnCollected;
        _diamond.EndCollected += OnEndCollected;
    }

    private void OnDisable()
    {
        _diamond.StartCollected -= OnCollected;
        _diamond.EndCollected -= OnEndCollected;
    }

    private void OnCollected()
    {
        StartCoroutine(FadeIn());
        _renderer.sortingLayerName = CollectedLayerName;
        
        var renderer = _trail.GetComponent<ParticleSystemRenderer>();
        renderer.sortingLayerName = CollectedLayerName;

        renderer = _star.GetComponent<ParticleSystemRenderer>();
        renderer.sortingLayerName = CollectedLayerName;

        for (int i = 0; i < _star.transform.childCount; i++)
        {
            renderer = _star.transform.GetChild(i).GetComponent<ParticleSystemRenderer>();
            renderer.sortingLayerName = CollectedLayerName;
        }
    }

    private void OnEndCollected()
    {
        _renderer.enabled = false;
        _star.Stop();
        _trail.Stop();
    }

    public void Recolor()
    {
        _renderer.color = _elements[_diamond.Element].MainColor;
        _light.color = Color.Lerp(Color.white, _elements[_diamond.Element].MainColor, 0.5f);
        var main = _trail.main;
        main.startColor = _elements[_diamond.Element].AdditionalColor;

        main = _star.transform.GetChild(0).GetComponent<ParticleSystem>().main;
        main.startColor = _elements[_diamond.Element].MainColor;
    }

    private IEnumerator FadeIn()
    {
        float factor = 1;
        float startIntensity = _light.intensity;

        while (factor > 0)
        {
            factor -= Time.deltaTime;
            _light.intensity = Mathf.Lerp(0, startIntensity, factor);
            yield return null;
        }
    }
}
