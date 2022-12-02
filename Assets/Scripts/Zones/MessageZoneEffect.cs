using UnityEngine;
using UnityEngine.Events;

public class MessageZoneEffect : BaseZoneEffect
{
    [SerializeField] private Message _message;

    public event UnityAction<Message> MessageShowed;

    public override void Apply(Player player)
    {
        if (enabled)
        {
            enabled = false;
            MessageShowed?.Invoke(_message);
        }
    }
}


