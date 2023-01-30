using UnityEngine;

[CreateAssetMenu(fileName = nameof(CharacterData), menuName = nameof(ScriptableObject) + " / " + nameof(CharacterData))]

public class CharacterData : ScriptableObject
{
    [field: SerializeField] public Element DeathEffects { get; private set; }
}
