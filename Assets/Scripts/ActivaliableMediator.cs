using UnityEngine;

public class ActivaliableMediator : MonoBehaviour
{
    [SerializeField] private BaseActivailiable[] _activailiables;
    [SerializeField] private BaseButton[] _buttons;

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
        {
            if (button.IsActive)
            {
                return;
            }
        }

        foreach (var activailiable in _activailiables)
        {
            activailiable.Deactivate();
        }
    }

    private void OnActivated()
    {
        foreach (var activailiable in _activailiables)
        {
            activailiable.Activate();
        }
    }
}
