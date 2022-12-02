using UnityEngine;

[CreateAssetMenu(fileName = nameof(Message), menuName = nameof(ScriptableObject) + " / " + nameof(Message))]
public class Message : ScriptableObject
{ 
    [field: SerializeField, Multiline(5)] public string Text { get; private set; }
    [field: SerializeField] public AudioClip Clip { get; private set; }
}
