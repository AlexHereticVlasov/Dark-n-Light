using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player damageable))
            Kill(damageable);
    }
    //ToDo: IDamageable?
    protected virtual void Kill(Player damageable) => damageable.TakeDamage();
}
