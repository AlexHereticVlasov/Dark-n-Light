using UnityEngine;

namespace Bridges
{
    public sealed class WaterBridge : NegativeBridge
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Player player))
            {
                if (player.Element == Elements.Water) return;

                player.SetIsJumpAble(false);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Player player))
            {
                if (player.Element == Elements.Water) return;

                player.SetIsJumpAble(true);
            }
        }
    }
}
