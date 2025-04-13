using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _clips;

    public void PlayRandomSound()
    {
        int index = Random.Range(0, _clips.Length);
        _source.PlayOneShot(_clips[index]);
    }
}
