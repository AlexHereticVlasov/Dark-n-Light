using System;
using UnityEngine;

[Serializable]
public sealed class Gun<TProjectile> where TProjectile : ProjectileMover
{
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private TProjectile _projectile;

    private Func<TProjectile, Vector3, Quaternion, TProjectile> _instantiate;

    public void Init(Func<TProjectile, Vector3, Quaternion, TProjectile> instantiate) => _instantiate = instantiate;

    public void Shoot() => _instantiate(_projectile, _shootPoint.Position, GetRotation());

    private Quaternion GetRotation()
    {
        Vector2 direction = GetDirection();
        float angle = Vector2.SignedAngle(Vector2.left, direction);
        return Quaternion.Euler(0, 0, angle);
    }

    public Vector2 GetDirection() => - (Vector2)_shootPoint.transform.localPosition;
}
