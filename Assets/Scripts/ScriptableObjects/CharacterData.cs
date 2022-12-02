using UnityEngine;

[CreateAssetMenu(fileName = nameof(CharacterData), menuName = nameof(ScriptableObject) + " / " + nameof(CharacterData))]

public class CharacterData : ScriptableObject
{
    [field: SerializeField] public ParticleSystem[] DeathEffects { get; private set; }
}
