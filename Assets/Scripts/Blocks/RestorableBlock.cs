using System.Collections;
using UnityEngine;

public class RestorableBlock : BaseDestructableBlock
{
    [SerializeField] private Collider2D _collider;

    protected override void Remove() => StartCoroutine(Restore());

    protected override bool ShouldMelt(Player player) => true;

    private IEnumerator Restore()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(3f);

        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            yield return ChangeTransperancy(factor);
        }

        _collider.enabled = true;
    }
}
