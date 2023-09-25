using UnityEngine;

public sealed class ActivailiableFog : BaseActivailiable
{
    [SerializeField] private Collider2D _collider;

    public override void Activate()
    {
        base.Deactivate();
        _collider.enabled = false;
    }

    public override void Deactivate()
    {
        base.Activate();
        _collider.enabled = true;
    }
}