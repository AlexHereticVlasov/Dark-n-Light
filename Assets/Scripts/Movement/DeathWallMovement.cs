using UnityEngine;

public sealed class DeathWallMovement : TrampMovement
{
    [SerializeField] private float _multiplier = 1.1f;
    [SerializeField] private float _rate = 10;

    private void Start() => InvokeRepeating(nameof(IncreaseSpeed), _rate, _rate);

    private void IncreaseSpeed() => Speed *= _multiplier;
}
