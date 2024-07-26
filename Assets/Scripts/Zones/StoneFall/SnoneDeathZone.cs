using UnityEngine;

namespace StoneFall
{
    public sealed class SnoneDeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FallingStone stone))
                stone.Kill();
        }
    }
}
