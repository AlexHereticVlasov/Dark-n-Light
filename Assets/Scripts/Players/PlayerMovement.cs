using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [Inject] private readonly IGravity _gravity;

    private void OnEnable() => _gravity.Reversed += OnGravityReversed;

    private void OnDisable() => _gravity.Reversed -= OnGravityReversed;

    private void OnGravityReversed() => _jumpDirection *= -1;

    private Vector2 _jumpDirection = Vector2.up;

    public event UnityAction Warped;

    public void SetXVelocity(float value) => _rigidbody.velocity = new Vector2(value, _rigidbody.velocity.y);

    public void Jump(float value)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(_jumpDirection * value);
    }

    public void AddForce(Vector2 force) => _rigidbody.AddForce(force, ForceMode2D.Force);

    public void Freaze()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
    }

    public void Unfreaze() => _rigidbody.isKinematic = false;

    public void Warp() => Warped?.Invoke();
}
