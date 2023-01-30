using UnityEngine;

public class DestructableBlock : BaseDestructableBlock
{
    protected override bool ShouldMelt(Player player) => player.Element == Element;

    protected override void Finish() => gameObject.SetActive(false);
}
