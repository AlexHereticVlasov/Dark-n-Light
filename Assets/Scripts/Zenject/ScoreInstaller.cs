using UnityEngine;
using Zenject;
using Timer;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] private Score _score;

    public override void InstallBindings()
    {
        Container.Bind<IScore>().FromInstance(_score).AsSingle().NonLazy();
        Container.Bind<IHardModeCounter>().FromInstance(_score).AsSingle().NonLazy();
        Container.Bind<IInitable>().FromInstance(_score).AsSingle().NonLazy();
        Container.QueueForInject(_score);
    }
}

public sealed class AmbientPlayerInstaller : MonoInstaller
{
    [SerializeField] private AmbientPlayer _ambientPlayer;

    public override void InstallBindings()
    {
        Container.Bind<IInitable>().FromInstance(_ambientPlayer).AsSingle().NonLazy();
        Container.QueueForInject(_ambientPlayer);
    }
}
