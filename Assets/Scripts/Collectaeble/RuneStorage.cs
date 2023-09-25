using UnityEngine;
using UnityEngine.Events;

namespace Runes
{
    public sealed class RuneStorage : MonoBehaviour, IRuneStorage
    {
        public event UnityAction<int> AmountChanged;

        public int Amount { get; private set; }

        public void Add()
        {
            Amount++;
            AmountChanged?.Invoke(Amount);
        }

        public bool TryRemove(int amount)
        {
            if (amount >= Amount)
            {
                Remove(amount);
                return true;
            }

            return false;
        }

        private void Remove(int amount)
        {
            Amount -= amount;
            AmountChanged?.Invoke(Amount);
        }
    }
}