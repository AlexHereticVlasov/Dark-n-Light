using UnityEngine;
using Zenject;

public class MenuHintInstaller : MonoInstaller
{
    [SerializeField] private MenuHint _menuHint;

    public override void InstallBindings()
    {
        Container.Bind<MenuHint>().FromInstance(_menuHint).AsSingle().NonLazy();
        Container.QueueForInject(_menuHint);
    }
}
