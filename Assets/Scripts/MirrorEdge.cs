using UnityEngine;
using UnityEngine.Events;

public sealed class MirrorEdge : BasePoint, IEffectOrigin
{
    public event UnityAction<Elements, Vector2> Spawned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            SpawnParticles(player);
    }

    private void SpawnParticles(Player player)
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 spawnPosition = new Vector2(transform.position.x, playerPosition.y);
        Spawned?.Invoke(player.Element, spawnPosition);
    }
}
