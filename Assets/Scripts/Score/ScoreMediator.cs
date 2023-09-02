using UnityEngine;
using Zenject;

namespace Timer
{
    public sealed class ScoreMediator : MonoBehaviour
    {
        [Inject] private IHardModeCounter _hardModeCounter;
        [Inject] private IHardModeLauncher _hardModeLauncher;

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

        private void OnTimeRestored() => _hardModeLauncher.Cancel();

        private void OnTimeIsOwer() => _hardModeLauncher.Launch();
    }
}

public interface IHardModeLauncher
{
    void Launch();
    void Cancel();

}
