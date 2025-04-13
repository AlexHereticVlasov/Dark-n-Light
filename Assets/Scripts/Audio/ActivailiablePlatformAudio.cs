using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(ActivaliblePlatform))]
public sealed class ActivailiablePlatformAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private ActivaliblePlatform _platform;

    private void OnEnable()
    {
        _platform.MovementStarted += OnMovementStarted;
        _platform.MovementStoped += OnMovementStoped;
    }

    private void OnDisable()
    {
        _platform.MovementStarted -= OnMovementStarted;
        _platform.MovementStoped -= OnMovementStoped;
    }

    private void OnMovementStoped() => _source.Stop();

    private void OnMovementStarted() =>  _source.Play();
}
