using Zenject;

public sealed class LightHardModeAdapter : HardModeAdapter
{
    [Inject] private IGlobalLighting _globalLighting;

    public override void Cancel() => _globalLighting.FadeOut();

    public override void Launch() => _globalLighting.FadeIn();
}
