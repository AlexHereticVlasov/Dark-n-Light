using System.Collections;
using UnityEngine;

public class RestorableBlock : BaseDestructableBlock
{
    [SerializeField] private Collider2D _collider;

    protected override void Finish() => StartCoroutine(RestoreRoutine());

    protected override bool ShouldMelt(Player player) => true;

    private IEnumerator RestoreRoutine()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(3f);

        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            yield return ChangeTransperancy(factor);
        }

        Restore();
    }

    protected override void Restore()
    {
        base.Restore();
        _isMelted = false;
        _collider.enabled = true;
    }
}
