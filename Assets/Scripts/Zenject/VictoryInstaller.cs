using UnityEngine;
using Zenject;

public class VictoryInstaller : MonoInstaller
{
    [SerializeField] private Victory _victory;

    public override void InstallBindings()
    {
        Container.Bind<Victory>().FromInstance(_victory).AsSingle().NonLazy();
        Container.QueueForInject(_victory);
    }
}
