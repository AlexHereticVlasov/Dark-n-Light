using UnityEngine;

public sealed class WindZoneView : MonoBehaviour
{
    [SerializeField] private BaseActivailiable _activailiableZone;
    [SerializeField] private ParticleSystem _particles;

    private void OnEnable()
    {
        _activailiableZone.Activated += OnActivated;
        _activailiableZone.Deactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        _activailiableZone.Activated -= OnActivated;
        _activailiableZone.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated() => _particles.Stop();

    private void OnActivated() => _particles.Play();
}
