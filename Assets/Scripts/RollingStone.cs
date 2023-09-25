using UnityEngine;

public sealed class RollingStone : MonoBehaviour, IActor
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _buttonsCount = 0;
    private bool _isSlowed;
    private float _defoultAngularDrag;
    private float _defoultDrag;

    private void Start()
    {
        _defoultDrag = _rigidbody.drag;
        _defoultAngularDrag = _rigidbody.angularDrag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PressingButton button) == false) return;

        _buttonsCount++;

        if (_isSlowed) return;

        Unslow();
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PressingButton button) == false) return;

        _buttonsCount--;

        if (_buttonsCount > 0) return;

        if (_isSlowed == false) return;

        Slow();
    }

    private void Unslow()
    {
        _isSlowed = true;
        _rigidbody.angularDrag = 3;
        _rigidbody.drag = 3;
    }

    private void Slow()
    {
        _isSlowed = false;
        _rigidbody.angularDrag = _defoultAngularDrag;
        _rigidbody.drag = _defoultDrag;
    }
}
