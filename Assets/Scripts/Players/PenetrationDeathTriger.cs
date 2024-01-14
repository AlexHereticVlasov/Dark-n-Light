using UnityEngine;

public class PenetrationDeathTriger : MonoBehaviour
{
    private IDamageable _damageable;

    private void Awake() => _damageable = transform.parent.GetComponent<IDamageable>();

    private void OnTriggerEnter2D(Collider2D collision) => _damageable.TakeDamage(float.MaxValue);
}
