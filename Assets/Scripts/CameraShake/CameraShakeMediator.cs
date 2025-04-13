using UnityEngine;
using Zenject;

namespace CameraShaker
{
    public sealed class CameraShakeMediator : MonoBehaviour
    {
        [Inject] private readonly ICameraShakeTimer _timer;
        [Inject] private readonly ICameraShake _cameraShake;

        [SerializeField] private AudioPlayer _player;

        private void OnEnable()
        {
            _timer.TimeIsRunnongOut += OnTimeIsRunnongOut;
            _cameraShake.Shaked += OnShaked;
        }


        private void OnDisable()
        {
            _timer.TimeIsRunnongOut -= OnTimeIsRunnongOut;
            _cameraShake.Shaked -= OnShaked;
        }

        private void OnTimeIsRunnongOut() => _cameraShake.StartShake();

        private void OnShaked() => _player.PlayRandomSound();
    }
}