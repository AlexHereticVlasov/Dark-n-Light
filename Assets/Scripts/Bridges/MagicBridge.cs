using System.Collections;
using UnityEngine;

namespace Bridges
{
    public abstract class MagicBridge : BaseActivailiable, IRecoloreable
    {
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private Vector2 _size = Vector2.one;
        [SerializeField, Range(0, 1)] private float _rateOverTimeMultiplier = 1;

        private WaitForSeconds _delay = new WaitForSeconds(1);

        [field: SerializeField] public bool IsActive { get; protected set; }

        private void Awake() => StartCoroutine(IsActive ? ActivateRoutine() : DeactivateRoutine());

        protected virtual IEnumerator ActivateRoutine()
        {
            _particles.Play();
            yield return _delay;
            _collider.enabled = true;
        }

        protected virtual IEnumerator DeactivateRoutine()
        {
            _particles.Stop();
            yield return _delay;
            _collider.enabled = false;
        }

        public void Recolor()
        {
            if (_size.x <= 0 || _size.y <= 0)
                throw new System.Exception("Size sides must be more then zero");

            _collider.size = _size;
            SetParticlesShapeSize();
            SetParticlesEmissionRateOverTime();

            //ToDo: Change color here if it need
        }

        private void SetParticlesEmissionRateOverTime()
        {
            var emission = _particles.emission;
            emission.rateOverTime = Mathf.RoundToInt(100 * _size.x * _size.y * _rateOverTimeMultiplier);
        }

        private void SetParticlesShapeSize()
        {
            var shape = _particles.shape;
            shape.scale = _size;
        }
    }
}
