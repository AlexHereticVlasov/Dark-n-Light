using System.Collections;
using UnityEngine;

public class SoulTrap : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        player.Capture();
        yield return base.Collect(player);
        Destroy(gameObject);
    }
}
