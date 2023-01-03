using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightPlatform : BaseActivailiable
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Light2D _light;

    public override void Activate()
    {
        base.Activate();
        _collider.enabled = true;
        _light.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _collider.enabled = false;
        _light.enabled = false;
    }
}
