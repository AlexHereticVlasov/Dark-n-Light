using UnityEngine;
using UnityEngine.Events;

public class SoulPrison : MonoBehaviour, IDamageable, IEffectOrigin
{
    [SerializeField] private Collider2D _collider;

    [field:SerializeField] public Elements Element { get; private set; }

    public event UnityAction<Elements> Spawned;

    public void TakeDamage()
    {
        _collider.enabled = false;
        var player = transform.GetChild(0).GetComponent<Player>();
        player.Unlish();
        Spawned?.Invoke(Element);
        Destroy(gameObject);
    }
}
