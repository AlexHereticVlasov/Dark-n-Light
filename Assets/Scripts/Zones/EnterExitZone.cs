using UnityEngine;

public class EnterExitZone : BaseZone
{
    [SerializeField] private BaseZoneEffect _exitEffect;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _exitEffect.Apply(player);
    }

}


