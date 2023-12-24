using UnityEngine;

public sealed class AimGun : MonoBehaviour, IGun //ToDo: Need to update this logic
{
    [SerializeField] private float _rate = 0.25f;
    [SerializeField] private LayerMask _mask;
    [field: SerializeField] public Gun<ProjectileMover> Gun { get; private set; }

    private void Start()
    {
        Gun.Init(Instantiate);
        InvokeRepeating(nameof(Shoot), _rate, _rate);
    }

    private void Shoot()
    {
        if (Aim())
            Gun.Shoot();
    }

    private bool Aim()
    {
        var hit = Physics2D.Raycast(transform.position, -Gun.GetDirection(), 100, _mask);
        return hit.transform.TryGetComponent(out Player player);
    }
}