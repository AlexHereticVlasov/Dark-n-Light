using UnityEngine;
using UnityEngine.Events;

public abstract class BaseActivator : MonoBehaviour
{
    public event UnityAction Activated;
    public event UnityAction Deactivated;

    [field:SerializeField] public bool IsActive { get; private set; }

    protected virtual void Activate()
    {
        IsActive = true;
        Activated?.Invoke();
    }

    protected virtual void Deactivate()
    {
        IsActive = false;
        Deactivated?.Invoke();
    }
}

public sealed class Altar : BaseActivator
{
    [SerializeField] private int _targetAmount;
    
    private int _currentAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_currentAmount == _targetAmount) return;

        if (collision.TryGetComponent(out Player player))
        {
            //Try Get Rune
            if (_currentAmount == _targetAmount)
                Activate();
        }
    }
}
