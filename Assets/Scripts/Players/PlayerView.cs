using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ColorBean _bean;

    private void OnEnable()
    {
        _renderer.color = _bean[_player.Element];
    }
}