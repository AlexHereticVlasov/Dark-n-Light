using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ButtonTextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _highlighted;

    private Color _normal;

    private void Awake() => _normal = _text.color;

    public void OnPointerClick(PointerEventData eventData) => OnPointerExit(eventData);

    public void OnPointerEnter(PointerEventData eventData) => _text.color = _highlighted;

    public void OnPointerExit(PointerEventData eventData) => _text.color = _normal;
}
