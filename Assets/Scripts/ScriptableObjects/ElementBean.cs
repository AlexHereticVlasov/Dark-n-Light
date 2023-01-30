using UnityEngine;

[CreateAssetMenu(fileName = nameof(ElementBean), menuName = nameof(ScriptableObject) + " / " + nameof(ElementBean))]
public class ElementBean : ScriptableObject
{
    [SerializeField] private Element[] _element;

    public Element this[Elements index] => _element[(int)index];
}
