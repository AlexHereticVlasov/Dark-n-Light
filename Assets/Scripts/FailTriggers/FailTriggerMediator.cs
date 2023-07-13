using UnityEngine;


namespace FailTrigger
{
    public class FailTriggerMediator : MonoBehaviour
    {
        [SerializeField] private BaseFailTrigger[] _failTriggers;
        [SerializeField] private FailVoice _failVoice;

        private void OnEnable()
        {
            foreach (var trigger in _failTriggers)
                trigger.Activated += OnActivated;
        }

        private void OnDisable()
        {
            foreach (var trigger in _failTriggers)
                trigger.Activated -= OnActivated;
        }

        private void OnActivated()
        {
            _failVoice.Speak();
        }
    }
}