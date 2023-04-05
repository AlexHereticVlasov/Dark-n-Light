using System.Collections;
using TMPro;
using UnityEngine;

public sealed class MessageView : MonoBehaviour
{
    private const string FadeInTrigger = "FadeIn";
    private const string FadeOutTrigger = "FadeOut";

    [SerializeField] private MessageZoneEffect _zoneEffect;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;

    private int _fadeInHash;
    private int _fadeOutHash;

    private void Awake()
    {
        _fadeInHash = Animator.StringToHash(FadeInTrigger);
        _fadeOutHash = Animator.StringToHash(FadeOutTrigger);
    }

    private void OnEnable() => _zoneEffect.MessageShowed += OnMessageShowed;

    private void OnDisable() => _zoneEffect.MessageShowed -= OnMessageShowed;

    private void OnMessageShowed(Message message) => StartCoroutine(DisplayMessage(message));

    private IEnumerator DisplayMessage(Message message)
    {
        yield return FadeOut(message);
        yield return FadeIn();    
    }

    private IEnumerator FadeOut(Message message)
    {
        _animator.SetTrigger(_fadeInHash);
        _text.text = message.Text;
        yield return new WaitForSeconds(message.Clip.length);
    }

    private IEnumerator FadeIn()
    {
        _animator.SetTrigger(_fadeOutHash);
        yield return new WaitForSeconds(1);
        _text.text = string.Empty;
    }
}