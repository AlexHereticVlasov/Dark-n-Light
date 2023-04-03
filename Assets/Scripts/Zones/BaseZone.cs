using UnityEngine;

public class BaseZone : MonoBehaviour
{
    [SerializeField] private BaseZoneEffect _enterEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _enterEffect.Apply(player);
    }
}


public abstract class BaseZoneEffect : MonoBehaviour
{
    public abstract void Apply(Player player);
}


