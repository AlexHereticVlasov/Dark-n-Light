using UnityEngine;

public class MesageVoice : MonoBehaviour
{
    [SerializeField] private MessageZoneEffect _zoneEffect;
    [SerializeField] private AudioSource _source;

    private void OnEnable()
    {
        _zoneEffect.MessageShowed += OnMessageShowed;
    }

    private void OnDisable()
    {
        _zoneEffect.MessageShowed -= OnMessageShowed;
    }

    private void OnMessageShowed(Message message)
    {
        _source.clip = message.Clip;
        _source.Play();
    }
}


