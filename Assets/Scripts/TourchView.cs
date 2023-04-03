using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TourchView : MonoBehaviour, IObjectViev
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Light2D _subLight;
    [SerializeField] private Tourch _tourch;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ParticleSystem _orb;
    [SerializeField] private SpriteRenderer _mark;

    private void OnEnable()
    {
        _tourch.Activated += OnActivated;
        _tourch.Deactivated += OnDeactivated;
    }

    private void Start()
    {
        if (_tourch.IsActive)
            OnActivated();
        else
            OnDeactivated();
    }

    private void OnDisable()
    {
        _tourch.Activated -= OnActivated;
        _tourch.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
        _renderer.color = Color.white;
        _light.gameObject.SetActive(false);
        _subLight.gameObject.SetActive(false);
        _orb.Stop();
    }

    private void OnActivated()
    {
        _renderer.color = Color.yellow;
        _light.gameObject.SetActive(true);
        _subLight.gameObject.SetActive(true);
        _orb.Play();
    }

    public void ChangeColor(Color color) => _mark.color = color;
}
