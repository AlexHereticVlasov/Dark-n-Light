using UnityEngine;

public sealed class Diamond : BaseCollectable
{
    [SerializeField] private Collider2D _collider;
    //[SerializeField] private ParticleSystem _particles;

    protected override bool CanCollect(Player player) => player.Element == Element || Element == Elements.Astral;

    protected override void Collect(Player player)
    {
        _collider.enabled = false;
        //ToDo: Start BezierRoutine

        //Hack:Temp solution
        Destroy(gameObject);
        //_particles.Stop();
    }
}
