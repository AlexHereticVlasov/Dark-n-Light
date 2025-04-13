using UnityEngine;

public sealed class SpiriteSphere : BaseActivailiable
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public override void Activate()
    {
        base.Activate();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(float.MaxValue);
    }
}
