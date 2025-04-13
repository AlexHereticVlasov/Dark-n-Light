using UnityEngine;

public sealed class ActivationZoneEffect : BaseZoneEffect
{
    [SerializeField] private BaseActivailiable[] _activailiables;

    public override void Apply(Player player)
    {
        foreach (var activailiable in _activailiables)
            activailiable.Activate();
    }
}

