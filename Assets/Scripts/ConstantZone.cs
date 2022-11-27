using System.Collections.Generic;
using UnityEngine;

public class ConstantZone : MonoBehaviour
{
    [SerializeField] private BaseZoneEffect _constantEffect;

    private HashSet<Player> _players = new HashSet<Player>();

    private void FixedUpdate()
    {
        foreach (var player in _players)
            _constantEffect.Apply(player);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _players.Add(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _players.Remove(player);
    }

}


