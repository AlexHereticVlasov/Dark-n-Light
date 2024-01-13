using System.Collections;
using UnityEngine;

public class DangerZone : Trap
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override IEnumerator DealDamage(IDamageable damageable)
    {
        if (damageable.Element != Element)
            yield return base.DealDamage(damageable);
    }
}
