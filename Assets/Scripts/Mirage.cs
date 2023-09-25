using UnityEngine;

public sealed class Mirage : MonoBehaviour
{
    [SerializeField] private ActivailiableMirage _activailiable;

    private void OnEnable()
    {
        _activailiable.Activated += OnActivated;
        _activailiable.Deactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        _activailiable.Activated -= OnActivated;
        _activailiable.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
    }

    private void OnActivated()
    {
    }
}