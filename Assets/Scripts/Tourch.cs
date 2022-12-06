using UnityEngine;
using UnityEngine.Events;

public class Tourch : BaseActivator
{
    //[field: SerializeField] public bool IsActive { get; private set; }

    //public event UnityAction Activated;
    //public event UnityAction Deactivated;
    //ToDo:?states
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

    //private void TutnOff()
    //{
    //    IsActive = false;
    //    Deactivated?.Invoke();
    //}

    //private void TurnOn()
    //{
    //    IsActive = true;
    //    Activated?.Invoke();
    //}
}
