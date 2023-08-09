using UnityEngine;
using UnityEngine.Events;

namespace CameraShaker
{
    public interface ICameraShakeTimer
    {
        public event UnityAction TimeIsRunnongOut;
    }

    public sealed class CameraShakeTimer : MonoBehaviour, ICameraShakeTimer
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

