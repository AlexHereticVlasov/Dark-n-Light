using System.Collections;
using UnityEngine;

public class Soul : BaseCollectable
{
    private readonly float _speed = 3;

    [SerializeField] private Collider2D _collider;
    [SerializeField] private BaseActivailiable _destination;

    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        _collider.enabled = false;
        Spawn();
        yield return base.Collect(player);
        yield return FlyRoutine();
    }

    private IEnumerator FlyRoutine()
    {
        while (IsTargetReached() == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination.transform.position,
                                                                                _speed * Time.deltaTime);
            yield return null;
        }

        transform.SetParent(_destination.transform);
        _destination.Activate();
    }

    private bool IsTargetReached() => Vector2.Distance(transform.position, _destination.transform.position) <
                                                                                    _speed * Time.deltaTime;
}
