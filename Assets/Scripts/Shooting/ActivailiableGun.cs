using UnityEngine;

public sealed class ActivailiableGun : BaseActivailiable, IGun
{
    [SerializeField] private float _rate = 3;
    [SerializeField] private bool _isShootImidiatly;

    [field: SerializeField] public Gun<ProjectileMover> Gun { get; private set; }

    private void Awake()
    {
        Gun = new Gun<ProjectileMover>();
    }

    public override void Activate()
    {
        base.Activate();
        float time = _isShootImidiatly ? 0 : _rate;
        InvokeRepeating(nameof(Shoot), time, _rate);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        CancelInvoke(nameof(Shoot));
    }

    private void Shoot() => Gun.Shoot();
}
