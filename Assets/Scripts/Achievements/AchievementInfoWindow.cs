using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementInfoWindow : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _description;

    public void OnShow(Achievement achievement)
    {
        if (achievement == null)
        {
            Debug.Log("null achievement");
            return;
        }

        _image.sprite = achievement.Icon;
        _header.text = achievement.Name;
        _description.text = achievement.Discription;
    }

    public void OnHide(Achievement achievement)
    {
        if (achievement == null)
        {
            Debug.Log("null achievement");
            return;
        }
    }
}
