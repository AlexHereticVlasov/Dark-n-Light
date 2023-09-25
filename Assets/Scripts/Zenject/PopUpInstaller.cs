using UnityEngine;
using PopUp;
using Zenject;

public sealed class PopUpInstaller : MonoInstaller
{
    [SerializeField] private PopUpFabric _popUp;

    public override void InstallBindings()
    {
        Container.Bind<IPopUp>().FromInstance(_popUp).AsSingle().NonLazy();
        Container.QueueForInject(_popUp);
    }
}
