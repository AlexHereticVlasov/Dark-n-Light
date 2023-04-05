using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//ToDo: Think About Linked message zone effects
public sealed class MessageZoneEffect : BaseZoneEffect
{
    [SerializeField] private Message _message;
    [SerializeField] private float _delay = 0;

    public event UnityAction<Message> MessageShowed;

    public override void Apply(Player player)
    {
        if (enabled)
            StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        if (_delay > 0)
            yield return new WaitForSeconds(_delay);

        enabled = false;
        MessageShowed?.Invoke(_message);
    }
}


