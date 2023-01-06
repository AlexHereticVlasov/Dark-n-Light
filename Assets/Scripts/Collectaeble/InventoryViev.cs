using UnityEngine;
using Zenject;

public class InventoryViev : MonoBehaviour
{
    [SerializeField] private CellViev[] _cells;
    [SerializeField] private ColorBean _bean;
    
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

    private void OnAmountChanged(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length; i++)
            _cells[i].SetValue(diamonds[i]);
    }

    private void OnInitialized(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length; i++)
        {
            if (diamonds[i] != 0)
            {
                _cells[i].gameObject.SetActive(true);
                _cells[i].Init(_bean[(Elements)i]);
                _cells[i].SetValue(diamonds[i]);
            }
        }
    }
}
