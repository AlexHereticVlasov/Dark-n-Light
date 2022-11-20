using UnityEngine;

public class TourchView : MonoBehaviour
{
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
        {
            OnActivated();
        }
    }

    private void OnDisable()
    {
        _tourch.Activated -= OnActivated;
        _tourch.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
        _renderer.color = Color.blue;
    }

    private void OnActivated()
    {
        _renderer.color = Color.yellow;
    }
}
