using Cinemachine;
using UnityEngine;
using Zenject;

public sealed class CinemachineVirtualCameraInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    public override void InstallBindings()
    {
        Container.Bind<CinemachineVirtualCamera>().FromInstance(_virtualCamera).AsSingle().NonLazy();
        Container.QueueForInject(_virtualCamera);
    }
}
