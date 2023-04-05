using UnityEngine;
using Zenject;

namespace CameraShaker
{
    public sealed class CameraShakeMediator : MonoBehaviour
    {
        [Inject] private CameraShakeTimer _timer;
        [Inject] private CameraShake _cameraShake;

        private void OnEnable() => _timer.TimeIsRunnongOut += OnTimeIsRunnongOut;

        private void OnDisable() => _timer.TimeIsRunnongOut -= OnTimeIsRunnongOut;

        private void OnTimeIsRunnongOut() => _cameraShake.StartShake();
    }
}