using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 3.25f;
    private float _inAirSpeed = 3.25f / 2;
    private Vector2 _jumpDirection = Vector2.up;

    public void SetXVelocity(float value) => _rigidbody.velocity = new Vector2(value * _speed, _rigidbody.velocity.y);

    public void SetXVelocityInAir(float value) => _rigidbody.velocity = new Vector2(value * _inAirSpeed, _rigidbody.velocity.y);

    public void Jump(int value)
    {
        if (_rigidbody.velocity.y < 0)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);

        _rigidbody.AddForce(_jumpDirection * value);
    }

    public void AddForce(Vector2 force) => _rigidbody.AddForce(force, ForceMode2D.Force);
}
