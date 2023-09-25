using UnityEngine;


namespace GameObjectView
{
    public sealed class DangerZoneView : BaseDangerZoneView
    {
        protected override void SetParticlesShapeScale()
        {
            var shape = _particles.shape;
            shape.scale = new Vector2(_size.x - 0.5f, _size.y);
        }

        protected override void SetColliderSize()
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.size = _size;
        }

        protected override void SetMaterial()
        {
            _renderer.material = _bean[_zone.Element].PoolMaterial;
        }
    }
}