using UnityEngine;

public class DestructableBlockView : MonoBehaviour, IRecoloreable
{
    [SerializeField] private BaseDestructableBlock _block;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ColorBean _bean;

    private void OnEnable() => _block.TransperancyChanged += OnMelted;

    private void OnDisable() => _block.TransperancyChanged -= OnMelted;

    private void OnMelted(float alpha)
    {
        Color color = _renderer.color;
        color[3] = alpha;
        _renderer.color = color;
    }

    public void Recolor()
    {
        if (_block is DestructableBlock block)
            _renderer.color = _bean[block.Element];
    }
}
