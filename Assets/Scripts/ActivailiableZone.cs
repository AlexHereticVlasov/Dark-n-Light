using UnityEngine;

public sealed class ActivailiableZone : BaseActivailiable
{
    [SerializeField] private Collider2D _collider;

    public override void Activate()
    {
        base.Activate();
        _collider.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _collider.enabled = false;
    }
}