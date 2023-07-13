using UnityEngine;
using UnityEngine.Events;

public sealed class Shadow : MonoBehaviour, IEffectOrigin
{
    private const float Radius = 0.2f;

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private MirrorEdge _mirrorEdge;
    [SerializeField] private LayerMask _mask;

    public event UnityAction<Elements, Vector2> Spawned;

    private void OnEnable() => _movement.Warped += OnWarped;

    private void Update() => Follow();

    private void OnDisable() => _movement.Warped -= OnWarped;
    
    private void OnWarped()
    {
        if (IsWarpPossible())
            Blink();
    }

    private bool IsWarpPossible() => Physics2D.OverlapCircle(transform.position, Radius, _mask) == null;

    private void Blink()
    {
        Spawned?.Invoke(0, transform.position);
        Spawned?.Invoke(0, _movement.transform.position);
        _movement.transform.position = transform.position;
    }

    private void Follow() => transform.position = GetMirroredPosition();

    private Vector2 GetMirroredPosition()
    {
        Vector2 position = _movement.transform.position;
        float deltaX = position.x - _mirrorEdge.Position.x;
        Vector3 mirroredPosition = new Vector3(_mirrorEdge.Position.x - deltaX, position.y);
        return mirroredPosition;
    }
}