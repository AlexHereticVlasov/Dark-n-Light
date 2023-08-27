using CameraShaker;
using UnityEngine;
using Zenject;

namespace StoneFall
{
    public sealed class StoneFallingMediator : MonoBehaviour
    {
        [SerializeField] private StoneFallingZoneEffect _zoneEffect;
        [SerializeField] private FallingStoneFabric _stoneFabric;

        [Inject] private ICameraShake _cameraShake;

        private void OnEnable() => _zoneEffect.FallStarted += OnFallStarted;

        private void Start() => _stoneFabric.Init(StartCoroutine, _cameraShake);

        private void OnDisable() => _zoneEffect.FallStarted -= OnFallStarted;

        private void OnFallStarted()
        {
            _zoneEffect.FallStarted -= OnFallStarted;
            _stoneFabric.StartFall();
        }
    }
}
