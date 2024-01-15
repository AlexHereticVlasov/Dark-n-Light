using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private const float DamageRate = 0.2f;
    private readonly WaitForSeconds _delay = new WaitForSeconds(DamageRate);

    [SerializeField] private float _damageAmount = 1f;

    private List<IDamageable> _contacts = new List<IDamageable>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            _contacts.Add(damageable);
            StartCoroutine(DealDamage(damageable));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
            _contacts.Remove(damageable);
    }

    protected virtual IEnumerator DealDamage(IDamageable damageable)
    {
        while (_contacts.Contains(damageable))
        {
            damageable.TakeDamage(_damageAmount);
            yield return _delay;
        }
    }
}
