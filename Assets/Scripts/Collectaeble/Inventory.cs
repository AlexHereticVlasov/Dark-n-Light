using UnityEngine;
using UnityEngine.Events;

public sealed class Inventory : MonoBehaviour
{
    public event UnityAction<int[]> AmountChanged;
    public event UnityAction<int[]> Initialized;

    private int[] _diamonds;

    public void Init(int[] diamonds)
    {
        _diamonds = diamonds;
        Initialized?.Invoke(_diamonds);
    }

    public void Collected(Elements element)
    {
        _diamonds[(int)element] = _diamonds[(int)element] - 1;
        AmountChanged?.Invoke(_diamonds);
    }
}
