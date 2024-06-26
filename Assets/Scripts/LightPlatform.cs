using UnityEngine;


public class LightPlatform : BaseActivailiable
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            if (player.Element != Elements.Dark) return;

            player.TakeDamage(1); //Hack:TempSolution
        }
    }
}
