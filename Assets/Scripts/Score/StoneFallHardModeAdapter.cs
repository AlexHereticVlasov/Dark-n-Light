using StoneFall;
using UnityEngine;

public sealed class StoneFallHardModeAdapter : HardModeAdapter
{
    [SerializeField] private StoneFallingMediator _stoneFallingMediator;

    public override void Cancel()
    {
        //_stoneFallingMediator.StopFall();
    }

    public override void Launch()
    {
        //_stoneFallingMediator.StartLongFall();
    }
}
