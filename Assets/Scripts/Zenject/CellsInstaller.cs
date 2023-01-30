using UnityEngine;
using Zenject;

public sealed class CellsInstaller : MonoInstaller
{
    [SerializeField] private Cells _cells;

    public override void InstallBindings()
    {
        Container.Bind<Cells>().FromInstance(_cells).AsSingle().NonLazy();
        Container.QueueForInject(_cells);
    }
}