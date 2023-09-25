using UnityEngine;
using Zenject;

public sealed class GlobalLightingInstaller : MonoInstaller
{
    [SerializeField] private GlobalLighting _globalLighting;

    public override void InstallBindings()
    {
        Container.Bind<IGlobalLighting>().FromInstance(_globalLighting).AsSingle().NonLazy();
        Container.QueueForInject(_globalLighting);
    }
}
