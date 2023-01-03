using UnityEngine;

public class CameraShakeMediator : MonoBehaviour
{
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private float _averageRate;
    [SerializeField] private float _rateDiviaton;

    private float _timer;

    private void Awake() => RecalculateTimer();

    private void RecalculateTimer() => _timer = Random.Range(_averageRate - _rateDiviaton,
                                                             _averageRate + _rateDiviaton);

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            RecalculateTimer();
            _cameraShake.StartShake();
        }
    }
}
