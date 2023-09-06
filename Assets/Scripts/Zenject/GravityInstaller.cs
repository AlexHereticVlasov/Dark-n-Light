using UnityEngine;
using Zenject;

public sealed class GravityInstaller : MonoInstaller
{
    [SerializeField] private Gravity _gravity;

    public override void InstallBindings()
    {
        Container.Bind<IGravity>().FromInstance(_gravity).AsSingle().NonLazy();
        Container.QueueForInject(_gravity);
    }
}
