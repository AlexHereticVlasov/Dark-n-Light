using CameraShaker;
using UnityEngine;
using Zenject;

namespace StoneFall
{
    public sealed class StoneFallingMediator : MonoBehaviour
    {
        [SerializeField] private StoneFallingZoneEffect _zoneEffect;
        [SerializeField] private FallingStoneFabric _stoneFabric;

        [SerializeField] private float _timeBetweenFalls = 10;

        [Inject] private ICameraShake _cameraShake;

        private void OnEnable()
        {
            _zoneEffect.FallStarted += OnFallStarted;
            _stoneFabric.FallComplited += OnFallComplited;
        }

        private void Start() => _stoneFabric.Init(StartCoroutine, _cameraShake);

        private void OnDisable()
        {
            _zoneEffect.FallStarted -= OnFallStarted;
            _stoneFabric.FallComplited -= OnFallComplited;
        }

        private void OnFallStarted()
        {
            _zoneEffect.FallStarted -= OnFallStarted;
            _stoneFabric.StartFall();
        }

        private void OnFallComplited()
        {
            Invoke(nameof(Wait), _timeBetweenFalls);
        }

        private void Wait()
        {
            _zoneEffect.FallStarted += OnFallStarted;
        }
    }
}
