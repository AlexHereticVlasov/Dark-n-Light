using UnityEngine;
namespace StoneFall
{
    [RequireComponent(typeof(FallingStone))]
    public sealed class FallingStoneView : MonoBehaviour
    {
        [SerializeField] private FallingStone _stone;
        [SerializeField] private ParticleSystem[] _particles;

        private void OnEnable() => _stone.Hited += OnHited;

        private void OnDisable() => _stone.Hited -= OnHited;

        private void OnHited()
        {
            foreach (var particle in _particles)
            {
                var effect = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(effect.gameObject, effect.main.duration);
            }
        }
    }
}
