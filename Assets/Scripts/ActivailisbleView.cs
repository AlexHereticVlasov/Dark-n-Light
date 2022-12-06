using UnityEngine;

public class ActivailisbleView : MonoBehaviour, IObjectViev
{
    [SerializeField] private SpriteRenderer _renderer;

    public void ChangeColor(Color color)
    {
        _renderer.color = color;
    }
}
