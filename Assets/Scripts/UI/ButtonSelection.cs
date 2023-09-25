using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
    [SerializeField] private SelectableButton[] _buttons;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(_buttons[1].gameObject);

        foreach (var button in _buttons)
        {
            button.Selected += OnSelected;
            button.Deselected += OnDeselected;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Selected -= OnSelected;
            button.Deselected -= OnDeselected;
        }
    }

    private void OnDeselected(SelectableButton button)
    {
        
    }

    private void OnSelected(SelectableButton button)
    {
        
    }
}
