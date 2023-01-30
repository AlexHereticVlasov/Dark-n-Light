using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementMessage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public void Init(Achievement achivement)
    {
        _image.sprite = achivement.Icon;
        _text.text = achivement.Name;
    }
}
