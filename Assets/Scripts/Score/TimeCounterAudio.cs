using Timer;
using UnityEngine;
using Zenject;

public class TimeCounterAudio : MonoBehaviour
{
    private const int MinValueToPlaySound = 5;

    [Inject] private readonly IScore _score;
    [SerializeField] private AudioSource _source;

    private void OnEnable() => _score.ValueChanged += OnValueChanged;

    private void OnDisable() => _score.ValueChanged -= OnValueChanged;

    private void OnValueChanged(int value)
    {
        if (value > MinValueToPlaySound) return;

        //Undone: Add Timer tick sound
        //_source.Play();
    }
}
