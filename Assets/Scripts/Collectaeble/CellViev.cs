using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellViev : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    public void Init(Color color) => _image.color = color;

    public void SetValue(int value) => _text.text = value.ToString();
}