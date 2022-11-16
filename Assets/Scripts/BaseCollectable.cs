using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Collect(player);
    }

    protected abstract void Collect(Player player);
}
