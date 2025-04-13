using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public sealed class Explosion : MonoBehaviour
{
    private const float LiveTime = 3;

    [SerializeField] private CircleCollider2D _collider2D;

    private IEnumerator Start()
    {
        Debug.Log("BOOM!");
        yield return null;
        _collider2D.enabled = false;
        Destroy(gameObject, LiveTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(1);
    }
}
