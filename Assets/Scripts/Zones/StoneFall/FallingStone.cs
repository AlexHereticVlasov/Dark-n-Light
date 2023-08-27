using UnityEngine;
using UnityEngine.Events;

namespace StoneFall
{
    public sealed class FallingStone : MonoBehaviour
    {
        public event UnityAction Hited;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IDamageable damageable))
                DealDamage(damageable);
        }

        private void DealDamage(IDamageable damageable)
        {
            damageable.TakeDamage();
            Kill();
        }

        public void Kill()
        {
            Hited?.Invoke();
            Destroy(gameObject);
        }
    }

    [RequireComponent(typeof(Animator), typeof(FallingStone))]
    public sealed class FallingStoneAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
    }
}
