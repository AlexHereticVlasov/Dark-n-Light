using UnityEngine;

public class DestructableBlock : BaseDestructableBlock
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override bool ShouldMelt(Player player) => player.Element == Element;

    protected override void Remove() => gameObject.SetActive(false);
}

//public class DestructableBlockView : MonoBehaviour, IRecoloreable
//{
//    [SerializeField] private SpriteRenderer _renderer;
//    [SerializeField] private DestructableBlock _block;
//    [SerializeField] private ColorBean _bean;

//    public void Recolor()
//    {
//        _renderer.color = _bean[_block.Element];
//    }
//}
