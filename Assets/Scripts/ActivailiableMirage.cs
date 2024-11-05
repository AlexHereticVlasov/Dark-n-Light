using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public sealed class ActivailiableMirage : BaseActivailiable
{
    [SerializeField] private TilemapRenderer _renderer;

    public override void Activate()
    {
        base.Activate();
        StartCoroutine(FadeOut());
    }

    public override void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        var alpha = _renderer.material.color.a;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            ChangeTransperency(alpha);
            yield return null;
        }
    }

    private void ChangeTransperency(float alpha)
    {
        var oldColor = _renderer.material.color;
        var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        _renderer.material.color = newColor;
    }

    private IEnumerator FadeOut()
    {
        var alpha = _renderer.material.color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            ChangeTransperency(alpha);
            yield return null;
        }
    }
}
