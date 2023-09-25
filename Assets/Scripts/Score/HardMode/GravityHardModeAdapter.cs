using Zenject;

public sealed class GravityHardModeAdapter : HardModeAdapter
{
    [Inject] private IGravity _gravity;

    public override void Cancel() => _gravity.Reverse();

    public override void Launch() => _gravity.Reverse();
}
