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
        [SerializeField] private int _cyclesAmmount = 4;

        [Inject] private readonly ICameraShake _cameraShake;

        private Coroutine _fallRoutine;

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
            _fallRoutine = _stoneFabric.StartFall(_cyclesAmmount);
        }

        private void OnFallComplited() => Invoke(nameof(Wait), _timeBetweenFalls);

        private void Wait() => _zoneEffect.FallStarted += OnFallStarted;

        internal void StopFall() => StopCoroutine(_fallRoutine);

        internal void StartLongFall()
        {
            _zoneEffect.FallStarted -= OnFallStarted;
            _fallRoutine = _stoneFabric.StartFall(int.MaxValue);
        }
    }
}
