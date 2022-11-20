using UnityEngine;

public sealed class Diamond : BaseCollectable
{
    [field: SerializeField] public Elements Element { get; private set; }

    protected override bool CanCollect(Player player) => player.Element == Element;

    protected override void Collect(Player player)
    {
        Destroy(gameObject);
    }
}

public class DiamondViev : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    [SerializeField] private SpriteRenderer _renderer;

    //Hack:Temp Solution
    [SerializeField] private Color[] _colors;

    private void OnEnable()
    {
        _renderer.color = _colors[(int)_diamond.Element];
    }
}
