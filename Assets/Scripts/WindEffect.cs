using UnityEngine;

public class WindEffect : BaseZoneEffect
{
    private float _power = 9.81f * 1.2f;

    [SerializeField] private Vector2 _direction = Vector2.up;


    public override void Apply(Player player)
    {
        player.AddForce(_direction * _power);
    }
}


