using UnityEngine;


namespace GameObjectView
{
    //TODO:
    //Реализовать шейдер магического тумана
    //Градиентная Прозрачность по краям
    //Выглядит как дым
    //Можно настраивать цвет

    public sealed class DangerFogViev : BaseDangerZoneView
    {
        protected override void SetParticlesShapeScale()
        {
            var shape = _particles.shape;
            shape.scale = new Vector2(_size.x - 0.5f, _size.y - 0.5f);
        }

        protected override void SetColliderSize()
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.size = _size - Vector2.one * 0.5f;
        }

        //Hack:Temp Solution. Set material after Kate finish Danger Fog Shader
        protected override void SetMaterial()
        {
            var color = _bean[_zone.Element].MainColor;
            color.a = 0.33f;
            _renderer.material.color = color;
        }
    }
}