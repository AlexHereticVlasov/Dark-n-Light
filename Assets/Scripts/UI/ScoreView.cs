using UnityEngine;
using TMPro;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _score.ValueChanged += OnValueChanged;

    private void OnDisable() => _score.ValueChanged -= OnValueChanged;

    private void OnValueChanged(int value) => _text.text = value.ToString("D4");
}
