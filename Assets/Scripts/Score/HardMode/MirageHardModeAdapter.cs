using UnityEngine;

public sealed class MirageHardModeAdapter : HardModeAdapter
{
    [SerializeField] private ActivailiableMirage _activailiable;

    public override void Cancel() => _activailiable.Deactivate();

    public override void Launch() => _activailiable.Activate();
}
