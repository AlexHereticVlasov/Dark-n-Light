using UnityEngine;

public class PlayerDeathTriger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision) => _player.TakeDamage();
}
