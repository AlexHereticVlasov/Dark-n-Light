using UnityEngine;

public class FadePanel : MonoBehaviour
{
    private const string FadeIn = "FadeIn";

    [SerializeField] private Victory _victory;
    [SerializeField] private Lose _lose;
    [SerializeField] private Animator _animator;

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
