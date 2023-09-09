using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public sealed class ActivailiableMirage : BaseActivailiable
{
    [SerializeField] private TilemapRenderer _renderer;

    public override void Activate()
    {
        base.Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    private IEnumerator FadeIn()
    {
        var alpha = _renderer.material.color.a;

        yield return null;
    }
}
