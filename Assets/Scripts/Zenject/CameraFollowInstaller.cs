using UnityEngine;
using Zenject;

public class CameraFollowInstaller : MonoInstaller
{
    [SerializeField] private CameraFollow _cameraFollow;

    public override void InstallBindings()
    {
        Container.Bind<CameraFollow>().FromInstance(_cameraFollow).AsSingle().NonLazy();
        Container.QueueForInject(_cameraFollow);
    }
}
