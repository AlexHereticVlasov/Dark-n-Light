using UnityEngine;
using Zenject;

public sealed class PauseMenuInstaller : MonoInstaller
{
    [SerializeField] private PauseMenu _pauseMenu;

    public override void InstallBindings()
    {
        Container.Bind<IPauseMenu>().FromInstance(_pauseMenu).AsSingle().NonLazy();
        Container.QueueForInject(_pauseMenu);
    }
}
