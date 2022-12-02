using UnityEngine;

[CreateAssetMenu(fileName = nameof(ColorBean), menuName = nameof(ScriptableObject) + " / " + nameof(ColorBean))]
public class ColorBean : ScriptableObject
{
    [SerializeField] private Color[] _colors;

    public Color this[Elements index] => _colors[(int)index];
}
