using UnityEngine.Events;

namespace Runes
{
    public interface IRuneStorage
    {
        int Amount { get; }

        event UnityAction<int> AmountChanged;

        void Add();
        bool TryRemove(int amount);
    }
}