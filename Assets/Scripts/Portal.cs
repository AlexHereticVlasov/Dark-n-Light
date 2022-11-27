using System.Collections.Generic;
using UnityEngine;

public class Portal : BaseActivailiable
{
    private readonly float _force = 50;

    [SerializeField] private Portal _other;
    [SerializeField] private EdgeCollider2D _edge;

    private Vector2 _direction;
    private HashSet<Rigidbody2D> _bodies = new HashSet<Rigidbody2D>();
    
    [field: SerializeField] public Transform DestinationPoint { get; private set; }

    private void Start()
    {
        _direction = (transform.position - DestinationPoint.position).normalized;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            _other.Add(rigidbody);

            if (_bodies.Contains(rigidbody) == false)
            {
                //Hack: It's a Fake programming

                //ToDo: Calculate Target Position
                rigidbody.position = _other.DestinationPoint.position;
                rigidbody.AddForce(_direction * _force, ForceMode2D.Impulse);
                //ToDo: Recalculate velocity
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
