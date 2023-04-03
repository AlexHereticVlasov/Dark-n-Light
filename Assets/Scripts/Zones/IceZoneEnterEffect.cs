public class IceZoneEnterEffect : BaseZoneEffect
{
    public override void Apply(Player player) => player.SetIsOnIce(true);
}