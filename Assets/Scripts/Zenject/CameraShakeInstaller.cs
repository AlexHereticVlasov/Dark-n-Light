using CameraShaker;
using UnityEngine;
using Zenject;

public sealed class CameraShakeInstaller : MonoInstaller
{
    [SerializeField] private CameraShake _cameraShake;

    public override void InstallBindings()
    {
        Container.Bind<ICameraShake>().FromInstance(_cameraShake).AsSingle().NonLazy();
        Container.QueueForInject(_cameraShake);
    }
}
