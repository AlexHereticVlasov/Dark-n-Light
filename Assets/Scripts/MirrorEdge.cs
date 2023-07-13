using UnityEngine;
using UnityEngine.Events;

public sealed class MirrorEdge : BasePoint, IEffectOrigin
{
    public event UnityAction<Elements, Vector2> Spawned;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            Spawned?.Invoke(0, collision.contacts[0].point);
    }
}
