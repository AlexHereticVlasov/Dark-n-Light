using Pool;
using UnityEngine;
using UnityEngine.Events;

public sealed class PoolableParticles : MonoBehaviour, IPooleable
{
    [SerializeField] private ParticleSystem _particles;

    public event UnityAction<IPooleable> UseageComplited;

    public void Reuse()
    {
        _particles.Play();
    }
}
