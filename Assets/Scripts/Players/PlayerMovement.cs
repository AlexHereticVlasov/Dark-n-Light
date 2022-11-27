using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 3.25f;
    private float _inAirSpeed = 3.25f / 2;
    private float _onEartSpeed = 3.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WindEffect wind))
            _speed = _inAirSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WindEffect wind))
            _speed = _onEartSpeed;
    }

    public void SetXVelocity(float value) => _rigidbody.velocity = new Vector2(value * _speed, _rigidbody.velocity.y);

    public void Jump(int value) => _rigidbody.AddForce(Vector2.up * value);

    public void AddForce(Vector2 force) => _rigidbody.AddForce(force, ForceMode2D.Force);
}
