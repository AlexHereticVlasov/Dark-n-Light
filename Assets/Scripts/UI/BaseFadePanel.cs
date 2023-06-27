using UnityEngine;

public abstract class BaseFadePanel : MonoBehaviour
{
    private const string FadeInString = "FadeIn";
    private const string FadeOutString = "FadeOut";

    [SerializeField] private Animator _animator;

    protected int FadeInHash;
    protected int FadeOutHash;

    private void Awake()
    {
        FadeInHash = Animator.StringToHash(FadeInString);
        FadeOutHash = Animator.StringToHash(FadeOutString);
    }

    public void FadeIn() => _animator.SetTrigger(FadeInHash);

    public void FadeOut() => _animator.SetTrigger(FadeOutHash);
}
