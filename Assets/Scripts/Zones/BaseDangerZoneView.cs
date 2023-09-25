using UnityEngine;


namespace GameObjectView
{
    public abstract class BaseDangerZoneView : MonoBehaviour, IRecoloreable
    {
        [SerializeField] protected DangerZone _zone;
        [SerializeField] protected SpriteRenderer _renderer;
        [SerializeField] protected ElementBean _bean;
        [SerializeField] protected ParticleSystem _particles;

        [Header("Settings")]
        [SerializeField] protected Vector2 _size = Vector2.one;
        [SerializeField] private int _particleAmountMultiplier = 100;

        public void Recolor()
        {
            SetMaterial();

            if (_size.x <= 0 || _size.y <= 0)
                throw new System.Exception("Size must be more zero");

            SetParticlesStartColor();
            SetParticlesEmissionRateOverTime();
            SetParticlesShapeScale();
            _renderer.transform.localScale = _size;
            SetColliderSize();
        }

        protected abstract void SetParticlesShapeScale();

        protected abstract void SetColliderSize();

        protected abstract void SetMaterial();

        private void SetParticlesStartColor()
        {
            var main = _particles.main;
            main.startColor = _bean[_zone.Element].AdditionalColor;
        }

        private void SetParticlesEmissionRateOverTime()
        {
            var emission = _particles.emission;
            emission.rateOverTime = Mathf.RoundToInt(_particleAmountMultiplier * _size.x * _size.y);
        }
    }
}