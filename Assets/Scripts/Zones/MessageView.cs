using System.Collections;
using TMPro;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    private const string FadeIn = "FadeIn";
    private const string FadeOut = "FadeOut";

    [SerializeField] private MessageZoneEffect _zoneEffect;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;

    private int _fadeInHash;
    private int _fadeOutHash;

    private void Awake()
    {
        _fadeInHash = Animator.StringToHash(FadeIn);
        _fadeOutHash = Animator.StringToHash(FadeOut);
    }

    private void OnEnable() => _zoneEffect.MessageShowed += OnMessageShowed;

    private void OnDisable() => _zoneEffect.MessageShowed -= OnMessageShowed;

    private void OnMessageShowed(Message message) => StartCoroutine(DisplayMessage(message));

    private IEnumerator DisplayMessage(Message message)
    {
        _animator.SetTrigger(_fadeInHash);
        _text.text = message.Text;
        yield return new WaitForSeconds(message.Clip.length);
        _animator.SetTrigger(_fadeOutHash);
        yield return new WaitForSeconds(1);
        _text.text = string.Empty;
    }
}