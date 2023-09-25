using UnityEngine;
using Zenject;
using Runes;

public sealed class RuneStorageInstaller : MonoInstaller
{
    [SerializeField] private RuneStorage _storage;

    public override void InstallBindings()
    {
        Container.Bind<IRuneStorage>().FromInstance(_storage).AsSingle().NonLazy();
        Container.QueueForInject(_storage);
    }
}
