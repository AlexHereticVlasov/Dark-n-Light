using UnityEngine;
using Timer;
using TMPro;
using Zenject;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    [Inject] private IScore _score;

    private void OnEnable() => _score.ValueChanged += OnValueChanged;

    private void OnDisable() => _score.ValueChanged -= OnValueChanged;

    private void OnValueChanged(int value) => _text.text = value.ToString("D4");
}
