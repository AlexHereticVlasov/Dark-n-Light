using UnityEngine;
using Zenject;
using SceneLoad;

public class SceneLoaderInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _loader;
    public override void InstallBindings()
    {
        Container.Bind<ISceneLoader>().FromInstance(_loader).AsSingle().NonLazy();
        Container.QueueForInject(_loader);
    }
}
