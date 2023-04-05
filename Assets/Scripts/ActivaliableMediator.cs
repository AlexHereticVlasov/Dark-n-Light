using UnityEngine;

public class ActivaliableMediator : MonoBehaviour
{
    private bool _isActive = false;

    [SerializeField] private BaseActivailiable[] _activailiables;
    [SerializeField] private BaseActivator[] _buttons;
    [SerializeField] private Color _color;

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

        DeactivateAll();
    }

    private void OnActivated()
    {
        if (_isActive) return;

        _isActive = true;
        ActivateAll();
    }
    private void DeactivateAll()
    {
        foreach (var activailiable in _activailiables)
            activailiable.Deactivate();
    }

    private void ActivateAll()
    {
        foreach (var activailiable in _activailiables)
            activailiable.Activate();
    }

    public void Recolor()
    {
        IObjectViev[] vievs = GetComponentsInChildren<IObjectViev>();
        foreach (var viev in vievs)
            viev.ChangeColor(_color);
    }
}

