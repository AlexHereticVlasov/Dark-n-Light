using UnityEngine;

[CreateAssetMenu(fileName = nameof(Slide), menuName = nameof(ScriptableObject) + " / " + nameof(Slide))]
public sealed class Slide : ScriptableObject
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Message Message { get; private set; }
}