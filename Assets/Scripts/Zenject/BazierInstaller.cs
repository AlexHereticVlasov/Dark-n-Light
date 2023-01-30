using UnityEngine;
using Zenject;

public sealed class BazierInstaller : MonoInstaller
{
    [SerializeField] private BazierCurve _curve;

    public override void InstallBindings()
    {
        Container.Bind<BazierCurve>().FromInstance(_curve).AsSingle().NonLazy();
        Container.QueueForInject(_curve);
    }
}