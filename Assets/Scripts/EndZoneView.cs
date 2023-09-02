using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public sealed class EndZoneView : MonoBehaviour
{
    [SerializeField] private EndZoneActivailiable _endZone;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Light2D _light;

    private void OnEnable()
    {
        _endZone.Activated += OnActivated;
        _endZone.Deactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        _endZone.Activated -= OnActivated;
        _endZone.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
        _particles.Stop();
        _collider.enabled = false;
        _light.enabled = false;
    }

    private void OnActivated()
    {
        _particles.Play();
        _collider.enabled = true;
        _light.enabled = true;
    }
}