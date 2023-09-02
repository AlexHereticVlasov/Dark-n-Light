using TMPro;
using UnityEngine;
using Zenject;

namespace Runes
{
    public sealed class RuneStorageView : MonoBehaviour
    {
        [Inject] private IRuneStorage _storage;
        
        [SerializeField] private TMP_Text _text;

        private void OnEnable() => _storage.AmountChanged += OnAmountChanged;

        private void OnDisable() => _storage.AmountChanged -= OnAmountChanged;

        private void OnAmountChanged(int amount) => _text.text = amount.ToString("D2");
    }
}