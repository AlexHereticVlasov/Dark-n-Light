public class IceZoneExitEffect : BaseZoneEffect
{
    public override void Apply(Player player) => player.SetIsOnIce(false);
}


