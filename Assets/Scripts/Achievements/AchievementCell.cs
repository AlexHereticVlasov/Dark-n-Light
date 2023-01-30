using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class AchievementCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _image;

    private Achievement _achievement;

    public event UnityAction<Achievement> Show;
    public event UnityAction<Achievement> Hide;

    public void Init(Achievement achievement)
    {
        _achievement = achievement;
        _image.sprite = achievement.Icon;
    }

    public void OnPointerEnter(PointerEventData eventData) => Show?.Invoke(_achievement);

    public void OnPointerExit(PointerEventData eventData) => Hide?.Invoke(_achievement);
}
