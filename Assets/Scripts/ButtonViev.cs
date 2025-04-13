using UnityEngine;

public sealed class ButtonViev : MonoBehaviour, IObjectViev
{
    [SerializeField] private SpriteRenderer _renderer;

    public void ChangeColor(Color color) => _renderer.color = color;
}
