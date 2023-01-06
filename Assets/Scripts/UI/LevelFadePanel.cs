using UnityEngine;
using Zenject;

public class LevelFadePanel : MonoBehaviour
{
    private const string FadeIn = "FadeIn";

    [SerializeField] private Animator _animator;
    
    [Inject] private Lose _lose;
    [Inject] private Victory _victory;

    private int _fadeInHash;

    private void Awake() => _fadeInHash = Animator.StringToHash(FadeIn);

    private void OnEnable()
    {
        _victory.Win += OnWin;
        _lose.Defeate += OnDefeate;
    }

    private void OnDisable()
    {
        _victory.Win -= OnWin;
        _lose.Defeate -= OnDefeate;
    }

    private void OnDefeate() => _animator.SetTrigger(_fadeInHash);

    private void OnWin() => _animator.SetTrigger(_fadeInHash);
}