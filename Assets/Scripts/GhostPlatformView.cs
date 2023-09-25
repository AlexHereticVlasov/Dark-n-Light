using UnityEngine;

public sealed class GhostPlatformView : MonoBehaviour
{
    [SerializeField] private GhostPlatform _platform;
    [SerializeField] private SpriteRenderer[] _renderers;

    private void OnEnable()
    {
        _platform.TransperacyChanged += OnTransperacyChanged;
    }

    private void OnDisable()
    {
        _platform.TransperacyChanged -= OnTransperacyChanged;
    }

    private void OnTransperacyChanged(float arg0)
    {
        foreach (var sprite in _renderers)
        {
            var color = sprite.color;
            color.a = arg0;
            sprite.color = color;
        }
    }
}
