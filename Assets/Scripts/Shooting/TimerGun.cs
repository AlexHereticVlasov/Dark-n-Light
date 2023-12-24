using UnityEngine;

public sealed class TimerGun : MonoBehaviour, IGun
{
    [SerializeField] private float _rate = 3;
    [field: SerializeField] public Gun<ProjectileMover> Gun { get; private set; }

    private void Start()
    {
        Gun.Init(Instantiate);
        InvokeRepeating(nameof(Shoot), _rate, _rate);
    }

    private void Shoot() => Gun.Shoot();
}
