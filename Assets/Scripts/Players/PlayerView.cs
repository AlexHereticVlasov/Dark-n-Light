using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ElementBean _bean;

    private ParticleSystem _body;

    private void Start()
    {
        _body = Instantiate(_bean[_player.Element].Body, transform.position, Quaternion.identity, transform);
        _renderer.enabled = false;
    }

    private void OnEnable()
    {
        _renderer.color = _bean[_player.Element].MainColor;
        _player.Death += OnDeath;
        _player.Captured += OnCaptured;
        _player.Unlished += OnUnlished;
    }

    private void OnDisable()
    {
        _player.Death -= OnDeath;
        _player.Captured -= OnCaptured;
        _player.Unlished -= OnUnlished;
    }

    private void OnDeath(Vector2 position) => _body.Stop();

    private void OnCaptured() => _body.Pause();

    private void OnUnlished() => _body.Play();
}