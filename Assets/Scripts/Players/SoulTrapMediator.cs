using UnityEngine;

public class SoulTrapMediator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SoulPrison _template;

    private void OnEnable()
    {
        _player.Captured += OnCaptured;
        _player.Unlished += OnUnlished;
    }

    private void OnDisable()
    {
        _player.Captured -= OnCaptured;
        _player.Unlished -= OnUnlished;
    }

    private void OnUnlished()
    {
        _collider.enabled = true;
        transform.rotation = Quaternion.identity;
    }

    private void OnCaptured()
    {
        _collider.enabled = false;
        var prison = Instantiate(_template, transform.position, Quaternion.identity);
        transform.SetParent(prison.transform);
    }
}
