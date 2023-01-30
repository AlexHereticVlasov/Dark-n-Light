using UnityEngine;
using Zenject;

public class InventoryViev : MonoBehaviour
{
    [Inject] private Cells cells;
    [Inject] private Inventory _inventory;

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

    private void OnAmountChanged(int[] diamonds) => cells.ChangeAmount(diamonds);

    private void OnInitialized(int[] diamonds) => cells.Init(diamonds);
}
