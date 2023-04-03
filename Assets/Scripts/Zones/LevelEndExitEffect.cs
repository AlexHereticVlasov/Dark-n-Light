using UnityEngine.Events;

public class LevelEndExitEffect : BaseZoneEffect
{
    public event UnityAction<Player> Playeroutside;

    public override void Apply(Player player) => Playeroutside?.Invoke(player);
}
