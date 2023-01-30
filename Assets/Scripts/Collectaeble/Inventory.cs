using UnityEngine;
using UnityEngine.Events;

public sealed class Inventory : MonoBehaviour
{
    public event UnityAction<int[]> AmountChanged;
    public event UnityAction<int[]> Initialized;
    public event UnityAction<Elements> AllWasCollected;

    private int[] _diamonds;
    private int[] _collected;

    
    
    public void Init(int[] diamonds)
    {
        _diamonds = diamonds;
        _collected = new int[_diamonds.Length];
        Initialized?.Invoke(_diamonds);
    }

    public void Collected(Elements element)
    {
        _diamonds[(int)element]--;
        _collected[(int)element]++;
        AmountChanged?.Invoke(_diamonds);

        if (_diamonds[(int)element] == 0)
            AllWasCollected?.Invoke(element);
    }
}
