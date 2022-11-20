using UnityEngine;

public class DestructableBlockView : MonoBehaviour
{
    [SerializeField] private DestructableBlock _block;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable() => _block.Melted += OnMelted;

    private void OnDisable() => _block.Melted -= OnMelted;

    private void OnMelted(float alpha)
    {
        Color color = _renderer.color;
        color[3] = alpha;
        _renderer.color = color;
    }
}
