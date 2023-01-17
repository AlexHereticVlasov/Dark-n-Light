using UnityEngine.Events;

public class LevelEndEnterEffect : BaseZoneEffect
{
    public event UnityAction<Player> PlayerInside;

    public override void Apply(Player player) => PlayerInside?.Invoke(player);
}
