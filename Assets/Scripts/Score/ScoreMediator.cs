using UnityEngine;
using Zenject;

namespace Timer
{
    public sealed class ScoreMediator : MonoBehaviour
    {
        [Inject] private IHardModeCounter _hardModeCounter;

        private void OnEnable()
        {
            _hardModeCounter.TimeIsOwer += OnTimeIsOwer;
            _hardModeCounter.TimeRestored += OnTimeRestored;
        }

        private void OnDisable()
        {
            _hardModeCounter.TimeIsOwer -= OnTimeIsOwer;
            _hardModeCounter.TimeRestored -= OnTimeRestored;
        }

        private void OnTimeRestored()
        {
            Debug.Log("Restored");
        }

        private void OnTimeIsOwer()
        {
            Debug.Log("Over");
        }
    }
}