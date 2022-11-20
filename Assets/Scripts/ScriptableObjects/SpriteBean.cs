using UnityEngine;

[CreateAssetMenu(fileName = nameof(SpriteBean), menuName = nameof(ScriptableObject) + " / " + nameof(SpriteBean))]
public class SpriteBean : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;

    public Sprite this[Elements index] => _sprites[(int)index];
}
