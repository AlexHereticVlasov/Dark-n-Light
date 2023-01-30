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
        //ToDo: Subscribe on Level FinalState and stop body particles when it begun
        _renderer.color = _bean[_player.Element].MainColor;
        _player.Death += OnDeath;
    }

    private void OnDisable() => _player.Death -= OnDeath;

    private void OnDeath()
    {
        _body.Stop();
        //_renderer.enabled = false;
    }
}