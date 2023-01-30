using UnityEngine;

public class DangerZone : Trap
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override void Kill(IDamageable damageable)
    {
        if (damageable.Element != Element)
            base.Kill(damageable);
    }
}
