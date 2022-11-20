using UnityEngine;

public class DangerZone : Trap
{
    [SerializeField] private Elements _element;

    protected override void Kill(Player player)
    {
        if (player.Element != _element)
            base.Kill(player);
    }
}
