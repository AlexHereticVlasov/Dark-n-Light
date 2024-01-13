using UnityEngine;
using Zenject;

public sealed class PlayersArrayInstaller : MonoInstaller
{
    [SerializeField] private Player[] _players;

    public override void InstallBindings()
    {
        Container.Bind<Player[]>().FromInstance(_players).AsSingle().NonLazy();
        Container.QueueForInject(_players);
    }
}
