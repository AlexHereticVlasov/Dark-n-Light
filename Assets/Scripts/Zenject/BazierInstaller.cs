using UnityEngine;
using Zenject;

public sealed class BazierInstaller : MonoInstaller
{
    [SerializeField] private BazierCurve _curve;

    public override void InstallBindings()
    {
        Container.Bind<IBazier>().FromInstance(_curve).AsSingle().NonLazy();
        Container.QueueForInject(_curve);
    }
}

public sealed class PlayersInstaller : MonoInstaller
{
    [SerializeField] private Player[] _player;

    public override void InstallBindings()
    {
        Container.Bind<Player[]>().FromInstance(_player).AsSingle().NonLazy();
        Container.QueueForInject(_player);
    }
}