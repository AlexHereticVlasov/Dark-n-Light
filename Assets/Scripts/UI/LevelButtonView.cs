using TMPro;
using UnityEngine;

public sealed class LevelButtonView : MonoBehaviour
{
    private int LevelOffset = 1;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private LevelButton _button;

    private void Start() => _text.text = (_button.Value + LevelOffset).ToString("D2");
}
