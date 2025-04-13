using UnityEngine;

[CreateAssetMenu(fileName = nameof(RandomSoundList), menuName = nameof(ScriptableObject) + " / " + nameof(RandomSoundList))]
public sealed class RandomSoundList : BaseSoundList
{
    public AudioClip GetRandomClip() => Clips[Random.Range(0, Clips.Length)];
}