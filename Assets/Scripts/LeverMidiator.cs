using UnityEngine;

public class LeverMidiator : MonoBehaviour
{
    private bool _isActive;

    [SerializeField] private Interactable[] _interactables;
    [SerializeField] private BaseActivailiable[] _activailiables;

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
}
