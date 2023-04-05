using UnityEngine;
using UnityEngine.Events;

namespace CameraShaker
{
    public sealed class CameraShakeTimer : MonoBehaviour
    {
        [SerializeField] private float _averageRate;
        [SerializeField] private float _rateDiviaton;

        private float _timer;

        public event UnityAction TimeIsRunnongOut;

        private void Awake() => RecalculateTimer();

        private void Update()
        {
            _timer -= Time.deltaTime;
            CheckIsTimeIsRunningOut();
        }

        private void CheckIsTimeIsRunningOut()
        {
            if (_timer <= 0)
            {
                RecalculateTimer();
                TimeIsRunnongOut?.Invoke();
            }
        }

        private void RecalculateTimer() => _timer = Random.Range(_averageRate - _rateDiviaton,
                                                             _averageRate + _rateDiviaton);
    }
}

