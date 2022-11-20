using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 3;

    public void SetXVelocity(float value) => _rigidbody.velocity = new Vector2(value * _speed, _rigidbody.velocity.y);

    public void Jump(int value) => _rigidbody.AddForce(Vector2.up * value);
}
