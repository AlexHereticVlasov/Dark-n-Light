using UnityEngine;
using UnityEngine.Events;

public class SoulPrison : MonoBehaviour, IDamageable, IEffectOrigin
{
    [SerializeField] private Collider2D _collider;

    public float MaxHealth { get; private set; }
    [field: SerializeField] public float Health { get; private set; }
    [field:SerializeField] public Elements Element { get; private set; }

    public event UnityAction<Elements, Vector2> Spawned;
    public event UnityAction<float, float> HealthChanged;
    //ToDo: Use health
    public void TakeDamage()
    {
        _collider.enabled = false;
        var player = transform.GetChild(0).GetComponent<Player>();
        player.Unlish();
        Spawned?.Invoke(Element, transform.position);
        Destroy(gameObject);
    }
}
