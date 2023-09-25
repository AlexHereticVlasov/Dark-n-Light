using UnityEngine;
using Zenject;

public sealed class HardModeLauncerInstaller : MonoInstaller
{
    [SerializeField] private HardModeLauncher _launcher;

    public override void InstallBindings()
    {
        Container.Bind<IHardModeLauncher>().FromInstance(_launcher).AsSingle().NonLazy();
        Container.QueueForInject(_launcher);
    }
}
