using System.Collections;
using UnityEngine;

public class GeluPart : BaseCollectable
{
    protected override bool CanCollect(Player player) => true;

    protected override IEnumerator Collect(Player player)
    {
        yield return base.Collect(player);
        yield return new WaitForSeconds(1);
        //Win
    }
}
