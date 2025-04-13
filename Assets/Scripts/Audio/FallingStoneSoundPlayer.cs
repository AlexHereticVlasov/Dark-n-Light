using StoneFall;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class FallingStoneSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RandomSoundList _soundList;

        private void Start() => _audioSource.PlayOneShot(_soundList.GetRandomClip());
    }

