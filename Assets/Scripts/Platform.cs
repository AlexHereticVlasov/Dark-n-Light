using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            player.transform.SetParent(null);
        }
    }
}
