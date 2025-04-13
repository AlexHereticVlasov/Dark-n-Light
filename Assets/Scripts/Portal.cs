using System.Collections.Generic;
using UnityEngine;

public class Portal : BaseActivailiable
{
    [SerializeField] private Portal _other;
    [SerializeField] private EdgeCollider2D _edge;

    private readonly HashSet<Rigidbody2D> _bodies = new();
    
    [field: SerializeField] public Transform DestinationPoint { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            _other.Add(rigidbody);

            if (_bodies.Contains(rigidbody) == false)
            {
                var magnitude = rigidbody.velocity.magnitude;
                rigidbody.velocity = Vector2.zero;
                Vector3 direction = _other.transform.TransformDirection(Vector3.right) - transform.TransformDirection(Vector3.left);
                rigidbody.position = _other.DestinationPoint.position;
                rigidbody.AddForce(direction * magnitude, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
            if (_bodies.Contains(rigidbody))
                _bodies.Remove(rigidbody);
    }

    public override void Activate()
    {
        base.Activate();
        _edge.isTrigger = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _edge.isTrigger = false;
    }

    public void Add(Rigidbody2D rigidbody) => _bodies.Add(rigidbody);
}
