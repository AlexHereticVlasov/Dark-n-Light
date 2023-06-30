using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
            Kill(damageable);
    }

    protected virtual void Kill(IDamageable damageable) => damageable.TakeDamage();
}
