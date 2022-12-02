using UnityEngine;

public class DangerZone : Trap
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override void Kill(Player player)
    {
        if (player.Element != Element)
            base.Kill(player);
    }
}
