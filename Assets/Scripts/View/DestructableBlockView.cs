using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//namespace GameObjectView
//{
public class DestructableBlockView : MonoBehaviour, IRecoloreable
{
    [SerializeField] private BaseDestructableBlock _block;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ElementBean _bean;
    [SerializeField] private ShadowCaster2D _shadowCaster;

    private void OnEnable()
    {
        _block.Spawned += OnStartMelted;
        _block.TransperancyChanged += OnMelted;
        _block.Restored += OnRestored;
    }

    private void OnDisable()
    {
        _block.Spawned -= OnStartMelted;
        _block.TransperancyChanged -= OnMelted;
        _block.Restored -= OnRestored;
    }

    private void OnMelted(float alpha)
    {
        Color color = _renderer.color;
        color[3] = alpha;
        _renderer.color = color;
    }

    private void OnRestored() => _shadowCaster.enabled = true;

    private void OnStartMelted(Elements element) => _shadowCaster.enabled = false;

    public void Recolor()
    {
        if (_block is DestructableBlock block)
            _renderer.color = _bean[block.Element].MainColor;
    }
}
//}