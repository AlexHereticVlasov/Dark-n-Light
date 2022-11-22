using UnityEngine;

public class DestructableBlock : BaseDestructableBlock
{
    [SerializeField] private Elements _element;

    protected override bool ShouldMelt(Player player) => player.Element == _element;

    protected override void Remove() => gameObject.SetActive(false);
}
