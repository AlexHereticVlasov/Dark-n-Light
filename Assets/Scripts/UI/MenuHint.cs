using UnityEngine;
using TMPro;

public interface IMenuHint
{
    void Show(string message);
    void Hide();
}

public class MenuHint : MonoBehaviour, IMenuHint
{
    [SerializeField] private TMP_Text _text;

    public void Show(string message) => _text.text = message;

    public void Hide() => _text.text = string.Empty;
}
