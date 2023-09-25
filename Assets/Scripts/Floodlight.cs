using System.Collections;
using UnityEngine;


[RequireComponent(typeof(PressingButton))]
public class Floodlight : BaseActivailiable
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;
    [SerializeField] private Collider2D _collider;

    public override void Activate()
    {
        base.Activate();
        StartCoroutine(TurnOn());
    }

    public override void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            _light.pointLightInnerAngle = Mathf.Lerp(16, 0, factor);
            _light.pointLightOuterAngle = Mathf.Lerp(32, 0, factor);
            yield return null;
        }

        _collider.enabled = false;
    }

    private IEnumerator TurnOn()
    {
        float factor = 0;
        while (factor < 1)
        {
            factor += Time.deltaTime;
            _light.pointLightInnerAngle = Mathf.Lerp(0, 16, factor);
            _light.pointLightOuterAngle = Mathf.Lerp(0, 32, factor);
            yield return null;
        }

        _collider.enabled = true;
    }
}
