using UnityEngine;

namespace Runes
{
    public class Rune : BaseCollectable
    {
        protected override bool CanCollect(Player player) => true;
    }

    public class RuneView : MonoBehaviour
    {
        private Rune _rune;

        private void OnEnable()
        {
            _rune.Collected += OnCollected;
        }

        private void OnDisable()
        {
            _rune.Collected -= OnCollected;
        }

        private void OnCollected(BaseCollectable collectable)
        {

        }
    }
}