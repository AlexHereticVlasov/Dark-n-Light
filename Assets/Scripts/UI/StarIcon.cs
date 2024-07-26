using UnityEngine;
using UnityEngine.UI;

public class StarIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public void Show() => _icon.enabled = true;
}
