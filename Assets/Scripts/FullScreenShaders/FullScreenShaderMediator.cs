using Timer;
using UnityEngine;
using Zenject;

namespace FullScreen
{
    public sealed class FullScreenShaderMediator : MonoBehaviour
    {
        [Inject] private readonly IHardModeCounter _score;
        [SerializeField] private FullScreenShader _runningTime;

        private void OnEnable()
        {
            _score.TimeIsOwer += OnTimeIsOwer;
            _score.TimeRestored += OnTimeRestored;
        }

        private void OnDisable()
        {
            _score.TimeIsOwer -= OnTimeIsOwer;
            _score.TimeRestored -= OnTimeRestored;
        }

        private void OnTimeRestored() => _runningTime.Stop();

        private void OnTimeIsOwer() => _runningTime.Play();
    }
}