using UnityEngine;
using UnityEngine.Events;
using Pool;

namespace StoneFall
{
    public sealed class FallingStone : MonoBehaviour, IPooleable
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public event UnityAction Hited;
        public event UnityAction<IPooleable> UseageComplited;

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
            UseageComplited?.Invoke(this);
            //gameObject.SetActive(false);
        }

        public void Reuse()
        {
            _rigidbody.velocity = Vector2.zero;
            gameObject.SetActive(true);
        }
    }

    [RequireComponent(typeof(Animator), typeof(FallingStone))]
    public sealed class FallingStoneAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
    }
}
