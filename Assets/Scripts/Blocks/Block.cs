using UnityEngine;
using UnityEngine.Events;
//ToDo:Create new class for frezeable block that implement IPhysicMovement
public class Block : MonoBehaviour, IActor, IPhysicMovement, IDamageable, IEffectOrigin
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private bool _isFreazeable;

    public event UnityAction<Elements, Vector2> Spawned;

    public Vector2 Velocity { get; private set; }
    public float AngularVelocity { get; private set; }

    [field: SerializeField] public Elements Element { get; private set; }

    public void SetParent(Transform parent)
    {
        if (_isFreazeable == false) return;

        transform.SetParent(parent);
    }

    public void Freaze()
    {
        if (_isFreazeable == false) return;

        Velocity = _rigidbody.velocity;
        AngularVelocity = _rigidbody.angularVelocity;
        _rigidbody.isKinematic = true;
    }

    public void Restore()
    {
        if (_isFreazeable == false) return;

        _rigidbody.velocity = Velocity;
        _rigidbody.angularVelocity = AngularVelocity;
        _rigidbody.isKinematic = false;
    }

    public void Move()
    {

    }

    public void TakeDamage()
    {
        Spawned?.Invoke(Element, transform.position);
        Destroy(gameObject);
    }
}

public interface IPhysicMovement
{
    Vector2 Velocity { get; }
    float AngularVelocity { get; }

    void Freaze();
    void Restore();
    void Move();
    void SetParent(Transform parent);
}
