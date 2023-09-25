using System.Collections;
using UnityEngine;

public class GeluPart : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        float counter = 5;
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * 5);
            yield return null;
        }

        yield return base.Collect(player);   
    }
}
