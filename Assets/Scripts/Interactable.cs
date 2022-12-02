using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public event UnityAction Interacted;

    //ToDo: Think about this lever logic
    public void Interact()
    {
        Debug.Log(nameof(Interact));
        Interacted?.Invoke();
    }
}
