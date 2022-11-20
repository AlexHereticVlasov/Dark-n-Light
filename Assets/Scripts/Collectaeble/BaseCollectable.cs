using UnityEngine;
//Diamonds
//Shots

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            if (CanCollect(player))
                Collect(player);
    }

    protected abstract void Collect(Player player);

    protected abstract bool CanCollect(Player player);
}
