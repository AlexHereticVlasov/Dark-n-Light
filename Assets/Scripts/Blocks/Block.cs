using UnityEngine;

public class Block : MonoBehaviour, IActor, IPhysicMovement
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public Vector2 Velocity { get; private set; }
    public float AngularVelocity { get ; private set ; }

    public void SetParent(Transform parent) => transform.SetParent(parent);

    public void Freaze()
    {
        Velocity = _rigidbody.velocity;
        AngularVelocity = _rigidbody.angularVelocity;
        _rigidbody.isKinematic = true;
    }

    public void Restore()
    {
        _rigidbody.velocity = Velocity;
        _rigidbody.angularVelocity = AngularVelocity;
        _rigidbody.isKinematic = false;
    }

    public void Move()
    {
    
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
