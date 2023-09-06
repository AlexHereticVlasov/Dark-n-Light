using UnityEngine;

[RequireComponent(typeof(AntigravityCollectable))]
public sealed class AntigravityCollectableView : MonoBehaviour
{
    [SerializeField] private AntigravityCollectable _collectable;
    [SerializeField] private ParticleSystem _particle;

    private void OnEnable()
    {
        _collectable.Collected += OnCollected;
    }

    private void OnDisable()
    {
        _collectable.Collected -= OnCollected;
    }

    private void OnCollected(BaseCollectable collectable)
    {
        _particle.Stop();
    }
}
