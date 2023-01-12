using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Inject] private MenuHint _hint;
    [SerializeField] private string _message;

    public void OnPointerClick(PointerEventData eventData) => _hint.Hide();

    public void OnPointerEnter(PointerEventData eventData) => _hint.Show(_message);

    public void OnPointerExit(PointerEventData eventData) => _hint.Hide();
}
