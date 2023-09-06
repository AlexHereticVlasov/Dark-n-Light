using UnityEngine;

public sealed class EndZoneHardModeAdapter : HardModeAdapter
{
    [SerializeField] private EndZoneActivailiable[] _endZones;

    public override void Cancel()
    {
        foreach (var zone in _endZones)
            zone.Activate();
    }

    public override void Launch()
    {
        foreach (var zone in _endZones)
            zone.Deactivate();
    }
}
