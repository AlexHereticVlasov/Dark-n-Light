using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public sealed class SelectableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public event UnityAction<SelectableButton> Selected;
    public event UnityAction<SelectableButton> Deselected;

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log($"select {name}");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log($"deselect {name}");
    }
}
