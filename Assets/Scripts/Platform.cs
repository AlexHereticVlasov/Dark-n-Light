using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            Parent(player);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            Unparent(player);
    }

    protected virtual void Parent(Player player) => player.transform.SetParent(transform);

    protected virtual void Unparent(Player player) => player.transform.SetParent(null);
}
