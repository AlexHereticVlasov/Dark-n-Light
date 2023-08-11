using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseCollectable : MonoBehaviour, IEffectOrigin
{
    public event UnityAction<BaseCollectable> Collected;
    public event UnityAction<Elements, Vector2> Spawned;

    [field: SerializeField] public int Cost { get; private set; } = 50;
    [field: SerializeField] public Elements Element { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            if (CanCollect(player))
                StartCoroutine(Collect(player));
    }

    protected virtual IEnumerator Collect(Player player)
    {
        Collected?.Invoke(this);
        yield return null;
    }

    protected abstract bool CanCollect(Player player);

    protected void Spawn() => Spawned?.Invoke(Element, transform.position);
}

public class Rune : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;
}

public class SunShard : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;
}
