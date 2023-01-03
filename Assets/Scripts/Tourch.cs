using UnityEngine;

public sealed class Tourch : BaseActivator
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (ShouldTurnOn(player))
                Activate();
            else if (ShouldTurnOff(player))
                Deactivate();
        }
    }

    private bool ShouldTurnOn(Player player) => player.Element == Elements.Light && IsActive == false;

    private bool ShouldTurnOff(Player player) => player.Element == Elements.Dark && IsActive;
}
