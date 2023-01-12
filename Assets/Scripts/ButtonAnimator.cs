using UnityEngine;

[RequireComponent(typeof(BaseButton))]
public class ButtonAnimator : MonoBehaviour
{
    private const string Return = "Return";
    private const string Press = "Press";

    [SerializeField] private BaseButton _button;
    [SerializeField] private Animator _animator;

    private int _returnHash;
    private int _pressHash;

    private void Awake()
    {
        _pressHash = Animator.StringToHash(Press);
        _returnHash = Animator.StringToHash(Return);
    }

    private void OnEnable()
    {
        _button.Activated += OnActivated;
        _button.Deactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        _button.Activated -= OnActivated;
        _button.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated() => _animator.SetTrigger(_returnHash);

    private void OnActivated() => _animator.SetTrigger(_pressHash);
}
