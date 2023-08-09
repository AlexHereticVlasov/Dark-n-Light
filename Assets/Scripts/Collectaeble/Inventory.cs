using UnityEngine;
using UnityEngine.Events;

public interface IInventory //ToDo: Separate if it need, think about it
{
    event UnityAction<int[]> AmountChanged;
    event UnityAction<int[]> Initialized;
    event UnityAction<Elements> AllWasCollected;

    void Init(int[] diamonds);
    void Collected(Elements element);
}

public sealed class Inventory : MonoBehaviour, IInventory
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
        CheckIsAllCollected(element);
    }

    private void CheckIsAllCollected(Elements element)
    {
        if (_diamonds[(int)element] == 0)
            AllWasCollected?.Invoke(element);
    }
}
