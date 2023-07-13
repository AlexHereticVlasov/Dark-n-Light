using UnityEngine;
using UnityEngine.Events;

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

public abstract class TrueVisionBaseZoneEffect : BaseZoneEffect
{
    [SerializeField] protected BaseFakeObject[] FakeObjects; 
}

public sealed class TrueVisionEnterZoneEffect : TrueVisionBaseZoneEffect
{
    public override void Apply(Player player)
    {
        foreach (var fake in FakeObjects)
            fake.BecomeTransperent();
    }
}

public sealed class TrueVisionExitZoneEffect : TrueVisionBaseZoneEffect
{
    public override void Apply(Player player)
    {
        foreach (var fake in FakeObjects)
            fake.BecomeNormal();
    }
}

public abstract class BaseFakeObject : MonoBehaviour
{
    public abstract void BecomeNormal();

    public abstract void BecomeTransperent();
}

public sealed class SpriteFakeObject : BaseFakeObject
{
    public override void BecomeNormal()
    {

    }

    public override void BecomeTransperent()
    {
        
    }
}


