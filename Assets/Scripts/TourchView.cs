using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TourchView : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Tourch _tourch;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable()
    {
        _tourch.Activated += OnActivated;
        _tourch.Deactivated += OnDeactivated;
    }

    private void Start()
    {
        if (_tourch.IsActive)
            OnActivated();
    }

    private void OnDisable()
    {
        _tourch.Activated -= OnActivated;
        _tourch.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
        _renderer.color = Color.white;
        //_light.intensity = 0;
        _light.gameObject.SetActive(false);
    }

    private void OnActivated()
    {
        _renderer.color = Color.yellow;
        _light.gameObject.SetActive(true);
        //_light.intensity = 1;
    }
}
