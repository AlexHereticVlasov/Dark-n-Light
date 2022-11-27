using UnityEngine;

public class RayHostMediator : MonoBehaviour
{
    [SerializeField] private RayHost[] _hosts;
    [SerializeField] private BaseActivailiable[] _activailiables;

    private bool _isActive;

    private void OnEnable()
    {
        foreach (var host in _hosts)
        {
            host.Activated += OnActivated;
            host.Deactivated += OnDeactivated;
        }
    }

    private void OnDisable()
    {
        foreach (var host in _hosts)
        {
            host.Activated -= OnActivated;
            host.Deactivated -= OnDeactivated;
        }
    }

    private void OnDeactivated()
    {
        foreach (var host in _hosts)
            if (host.IsActive)
                return;

        _isActive = false;

        foreach (var activailiable in _activailiables)
            activailiable.Deactivate();
    }

    private void OnActivated()
    {
        if (_isActive == false)
        {
            _isActive = true;

            foreach (var activailiable in _activailiables)
                activailiable.Activate();
        }
    }
}