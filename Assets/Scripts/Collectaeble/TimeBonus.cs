using System.Collections;
using UnityEngine;

public sealed class TimeBonus : BaseCollectable
{
    [SerializeField] private Collider2D _collider;

    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        _collider.enabled = false;
        yield return base.Collect(player);
        Spawn();
        Destroy(gameObject, 5);
    }
}
