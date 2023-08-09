using UnityEngine;
using Zenject;

public sealed class PopUpInstaller : MonoInstaller
{
    [SerializeField] private PopUp _popUp;

    public override void InstallBindings()
    {
        Container.Bind<IPopUp>().FromInstance(_popUp).AsSingle().NonLazy();
        Container.QueueForInject(_popUp);
    }
}
