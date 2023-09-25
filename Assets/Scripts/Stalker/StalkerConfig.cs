using UnityEngine;

[CreateAssetMenu(fileName = nameof(StalkerConfig), menuName = nameof(ScriptableObject) + " / " + nameof(StalkerConfig))]
public sealed class StalkerConfig : ScriptableObject
{ 
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float TrampLength { get; private set; }
    [field: SerializeField] public float FollowLength { get; private set; }
}
