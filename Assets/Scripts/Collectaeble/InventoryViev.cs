using UnityEngine;
using Zenject;

public class InventoryViev : MonoBehaviour
{
    [Inject] private ICells _cells;
    [Inject] private IInventory _inventory;

    private void OnEnable()
    {
        _inventory.Initialized += OnInitialized;
        _inventory.AmountChanged += OnAmountChanged;
    }

    private void OnDisable()
    {
        _inventory.Initialized -= OnInitialized;
        _inventory.AmountChanged -= OnAmountChanged;
    }

    private void OnAmountChanged(int[] diamonds) => _cells.ChangeAmount(diamonds);

    private void OnInitialized(int[] diamonds) => _cells.Init(diamonds);
}
