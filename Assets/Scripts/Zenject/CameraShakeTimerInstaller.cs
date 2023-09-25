using CameraShaker;
using UnityEngine;
using Zenject;

public sealed class CameraShakeTimerInstaller : MonoInstaller
{
    [SerializeField] private CameraShakeTimer _timer;

    public override void InstallBindings()
    {
        Container.Bind<ICameraShakeTimer>().FromInstance(_timer).AsSingle().NonLazy();
        Container.QueueForInject(_timer);
    }
}