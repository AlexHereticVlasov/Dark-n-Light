using UnityEngine;
using UnityEngine.Events;

public sealed class ActivaliableForce : BaseActivailiable, IEffectOrigin
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _forceAmount;

    private bool _wasActivated;

    public event UnityAction<Elements, Vector2> Spawned;

    public override void Activate()
    {
        if (_wasActivated) return;

        base.Activate();
        _body.AddForce(_direction.normalized * _forceAmount, ForceMode2D.Impulse);
        Spawned(Elements.Fire, transform.position);
        _wasActivated = true;
    }
}