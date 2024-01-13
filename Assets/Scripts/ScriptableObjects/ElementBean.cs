using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ElementBean), menuName = nameof(ScriptableObject) + " / " + nameof(ElementBean))]
public class ElementBean : ScriptableObject
{
    [SerializeField] private Element[] _element;

    public Element this[Elements index] => _element[(int)index];

    public int Length => _element.Length;

    internal string GetName(Elements element)
    {
        return _element[(int)element].GetName();
    }
}
