using System.Collections;

public sealed class Heart : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        player.Heal(1);
        yield return base.Collect(player);
    }
}
