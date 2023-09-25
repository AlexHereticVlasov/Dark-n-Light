using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerSettings), menuName = nameof(ScriptableObject) + " / " + nameof(PlayerSettings))]
public class PlayerSettings : ScriptableObject
{
    [field:SerializeField] public float NormalSpeed { get; private set; }
    [field: SerializeField] public float InAirSpeed { get; private set; }
    [field: SerializeField] public float OnIceSpeed { get; private set; }
    [field: SerializeField] public float NormalJumpForce { get; private set; }
    [field: SerializeField] public int Layer { get; private set; }

}
