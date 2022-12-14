using UnityEngine;
using Zenject;

public sealed class SlideShowinstaller : MonoInstaller
{
    [SerializeField] private SlideShow _slideShow;

    public override void InstallBindings()
    {
        Container.Bind<SlideShow>().FromInstance(_slideShow).AsSingle().NonLazy();
        Container.QueueForInject(_slideShow);
    }
}
