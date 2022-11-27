using UnityEngine;

public class TestActivailiable : BaseActivailiable
{
    [SerializeField] private SpriteRenderer _renderer;

    public override void Activate()
    {
        base.Activate();
        _renderer.color = Color.cyan;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _renderer.color = Color.white;
    }
}
