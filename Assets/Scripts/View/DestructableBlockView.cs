using UnityEngine;

public class DestructableBlockView : MonoBehaviour
{
    [SerializeField] private BaseDestructableBlock _block;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable() => _block.TransperancyChanged += OnMelted;

    private void OnDisable() => _block.TransperancyChanged -= OnMelted;

    private void OnMelted(float alpha)
    {
        Color color = _renderer.color;
        color[3] = alpha;
        _renderer.color = color;
    }
}
