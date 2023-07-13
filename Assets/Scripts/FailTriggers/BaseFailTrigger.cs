using UnityEngine;
using UnityEngine.Events;


namespace FailTrigger
{
    public abstract class BaseFailTrigger : MonoBehaviour
    {
        public event UnityAction Activated;

        public abstract void OnTriggerEnter2D(Collider2D collider);
        public abstract void OnTriggerExit2D(Collider2D collider);

        protected void Activate() => Activated?.Invoke();
    }

    public sealed class Level21FailTrigger : BaseFailTrigger
    {
        [SerializeField] private int _looseBallLimit;
        private int _losedBalls;

        public override void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out RollingStone stone))
            {
                _losedBalls++;
                if (_losedBalls == _looseBallLimit)
                    Activate();
            }
        }

        public override void OnTriggerExit2D(Collider2D collider)
        {
            ;
        }
    }
}