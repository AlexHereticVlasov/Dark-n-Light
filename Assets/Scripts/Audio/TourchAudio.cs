using UnityEngine;

[RequireComponent(typeof(Tourch), typeof(AudioSource))]
public sealed class TourchAudio : MonoBehaviour
{
    [SerializeField] private Tourch _tourch;
    [SerializeField] private AudioSource _source;

    [SerializeField] private RandomSoundList _fadeInList;
    [SerializeField] private RandomSoundList _wooshList;

    private void OnEnable()
    {
        _tourch.Activated += OnActivated;
        _tourch.Deactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        _tourch.Activated += OnActivated;
        _tourch.Deactivated += OnDeactivated;
    }

    private void OnDeactivated()
    {
        var clip = _fadeInList.GetRandomClip();
        _source.PlayOneShot(clip);   
    }

    private void OnActivated()
    {
        var clip = _wooshList.GetRandomClip();
        _source.PlayOneShot(clip);
    }
}
