using System.Collections;
using UnityEngine;

public class GeluPart : BaseCollectable
{
    [SerializeField] private float _speed = 5;

    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        float length = 5;
        while (length > 0)
        {
            length -= Time.deltaTime;
            yield return Move();
        }

        yield return base.Collect(player);   
    }

    private IEnumerator Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        yield return null;
    }
}
