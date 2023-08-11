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

/*
Forgotten... 
Disunited... 
Weak... 
We have waited so long for the cold heavens to finally give us a sign. 
And at last the stars flashed brighter...
The serpent once again clutched at its own tail... and the circle closed!
Now the time of the Ancients is over... 
In the dark corners of the Earth... 
Beneath the eternal rocks... 
In the depths of the ancient seas...
Buried alive in forgotten crypts our brothers still languish... 
Can you feel it? The power fills you again!
Wake up!
Our time has come, 
go and break the seals, black as the souls of our enemies. 
Bring freedom to those who have remained loyal to me...
And bring death to all who dare stand in your way.
 */
