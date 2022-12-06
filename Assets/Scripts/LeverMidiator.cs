using UnityEngine;

public class LeverMidiator : MonoBehaviour
{
    private bool _isActive;

    [SerializeField] private Interactable[] _interactables;
    [SerializeField] private BaseActivailiable[] _activailiables;
    [SerializeField] private Color _color;

    private void OnEnable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.Interacted += OnInteracted;
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.Interacted -= OnInteracted;
        }
    }

    private void OnInteracted()
    {
        foreach (var activaliable in _activailiables)
        {
            activaliable.Activate();
        }
    }

    public void Recolor()
    {
        var vievs = GetComponentsInChildren<IObjectViev>();
        foreach (var view in vievs)
            view.ChangeColor(_color);
    }
}
