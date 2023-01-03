using UnityEngine;

public class DestructableBlock : BaseDestructableBlock
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override bool ShouldMelt(Player player) => player.Element == Element;

    protected override void Remove() => gameObject.SetActive(false);
}
