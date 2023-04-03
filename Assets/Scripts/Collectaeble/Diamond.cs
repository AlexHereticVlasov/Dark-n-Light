using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public sealed class Diamond : BaseCollectable
{
    [SerializeField] private Collider2D _collider;
    [Inject] private BazierCurve _curve;

    public event UnityAction StartCollected;
    public event UnityAction EndCollected;

    protected override bool CanCollect(Player player) => player.Element == Element || Element == Elements.Astral;

    protected override IEnumerator Collect(Player player)
    {
        StartCollected?.Invoke();
        _collider.enabled = false;
        Spawn();

        yield return Fly();
        yield return base.Collect(player);

        EndCollected?.Invoke();
        Destroy(gameObject, 5f);
    }

    private IEnumerator Fly()
    {
        Vector2 position = transform.position;
         float factor = 0;
        while (factor < 1)
        {
            yield return null;
            factor += Time.deltaTime;
            transform.position = _curve.GetPosition(position, factor);
        }

        transform.SetParent(_curve.transform);
    }
}
