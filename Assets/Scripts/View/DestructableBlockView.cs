using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//namespace GameObjectView
//{
public class DestructableBlockView : MonoBehaviour, IRecoloreable
{
    private const string ColorProperty = "_Color";

    [SerializeField] private BaseDestructableBlock _block;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ElementBean _bean;
    [SerializeField] private ShadowCaster2D _shadowCaster;
    [SerializeField] private DissolvedEffect _effect;

    private void OnEnable()
    {
        _block.Spawned += OnStartMelted;
        _block.TransperancyChanged += OnMelted;
        _block.Restored += OnRestored;
    }

    private void Start()
    {
        Recolor();
        _effect.Init(_bean[_block.Element]);
    }

    private void OnDisable()
    {
        _block.Spawned -= OnStartMelted;
        _block.TransperancyChanged -= OnMelted;
        _block.Restored -= OnRestored;
    }

    private void OnMelted(float alpha) => _effect.Evaluate(alpha);

    private void OnRestored() => _shadowCaster.enabled = true;

    private void OnStartMelted(Elements element, Vector2 position) => _shadowCaster.enabled = false;

    public void Recolor()
    {
        if (_block is DestructableBlock)
        {
            _renderer.color = Color.white;
            _renderer.sprite = _bean[_block.Element].DestructableStone;
            _renderer.sharedMaterial.SetColor(ColorProperty, _bean[_block.Element].DissolveColor);
        }
    }
}
//}