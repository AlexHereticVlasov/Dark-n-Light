using UnityEngine;
using UnityEngine.Events;

public abstract class BaseCollectable : MonoBehaviour, IEffectOrigin
{
    public event UnityAction<BaseCollectable> Collected;
    public event UnityAction<Elements> Spawned;

    [field: SerializeField] public int Cost { get; private set; } = 50;
    [field: SerializeField] public Elements Element { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (CanCollect(player))
            {
                Collected?.Invoke(this);
                Spawned?.Invoke(Element);
                Collect(player);
            }
        }
    }

    protected abstract void Collect(Player player);

    protected abstract bool CanCollect(Player player);
}
