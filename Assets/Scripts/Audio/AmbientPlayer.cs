using UnityEngine;

public sealed class AmbientPlayer : MonoBehaviour, IInitable
{
    private AudioSource _source;
    private AudioClip _clip;

    public void Init(Level level)
    {
        _clip = level.AmbientSound;
        _source.clip = _clip;
        _source.loop = true;
        _source.Play();
    }
}