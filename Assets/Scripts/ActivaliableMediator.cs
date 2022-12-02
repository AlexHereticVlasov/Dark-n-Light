using UnityEngine;

public class ActivaliableMediator : MonoBehaviour
{
    private bool _isActive = false;

    [SerializeField] private BaseActivailiable[] _activailiables;
    [SerializeField] private BaseActivator[] _buttons;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.Activated += OnActivated;
            button.Deactivated += OnDeactivated;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Activated -= OnActivated;
            button.Deactivated -= OnDeactivated;
        }
    }

    private void OnDeactivated()
    {
        foreach (var button in _buttons)
            if (button.IsActive)
                return;

        _isActive = false;

        foreach (var activailiable in _activailiables)
            activailiable.Deactivate();
    }

    private void OnActivated()
    {
        if (_isActive) return;

        _isActive = true;

        foreach (var activailiable in _activailiables)
            activailiable.Activate();
    }
}
