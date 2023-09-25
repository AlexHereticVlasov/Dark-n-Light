using UnityEngine;
using Zenject;

public class LoseInstaller : MonoInstaller
{
    [SerializeField] private Lose _lose;

    public override void InstallBindings()
    {
        Container.Bind<ILose>().FromInstance(_lose).AsSingle().NonLazy();
        Container.QueueForInject(_lose);
    }
}
