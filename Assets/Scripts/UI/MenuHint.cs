using UnityEngine;
using TMPro;

public class MenuHint : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Show(string message) => _text.text = message;

    public void Hide() => _text.text = string.Empty;
}
