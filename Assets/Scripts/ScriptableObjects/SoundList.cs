using UnityEngine;

[CreateAssetMenu(fileName = nameof(SoundList), menuName = nameof(ScriptableObject) + " / " + nameof(SoundList))]
public sealed class SoundList : BaseSoundList
{ 
    public AudioClip this[int index] => Clips[index];
}
