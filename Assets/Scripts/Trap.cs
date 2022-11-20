using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Kill(player);
    }
    //ToDo: IDamageable?
    protected virtual void Kill(Player player) => player.TakeDamage();
}
