using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private Inventory _inventory;

    public override void InstallBindings()
    {
        Container.Bind<IInventory>().FromInstance(_inventory).AsSingle().NonLazy();
        Container.QueueForInject(_inventory);
    }
}