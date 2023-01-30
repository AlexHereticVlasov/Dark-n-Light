using System.Collections;
using UnityEngine;

public class Soul : BaseCollectable
{
    [SerializeField] private BaseActivailiable _destination;

    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        Spawn();
        yield return base.Collect(player);
        yield return FlyRoutine();
    }

    private IEnumerator FlyRoutine()
    {
        //Fly to destination Point
        while (IsTargetReached() == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination.transform.position, 5 * Time.deltaTime);
            yield return null;
        }

        transform.SetParent(_destination.transform);
        _destination.Activate();
    }

    private bool IsTargetReached()
    {
        return Vector2.Distance(transform.position, _destination.transform.position) > 0.1f;
    }
}
