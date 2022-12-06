using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressingButton : BaseButton
{
    private List<IActor> _actors = new List<IActor>();

    protected override void TryActivate(IActor actor)
    {
        _actors.Add(actor);
        if (_actors.Count == 1)
            Activate();
    }

    protected override void TryDeactivate(IActor actor)
    {
        _actors.Remove(actor);
        if (_actors.Count == 0)
            Deactivate();
    }
}

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

    protected void Deactivate()
    {
        IsActive = false;
        Deactivated?.Invoke();
    }
}

public abstract class BaseButton : BaseActivator
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IActor actor))
            TryActivate(actor);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IActor actor))
            TryDeactivate(actor);
    }

    protected abstract void TryActivate(IActor actor);
    protected abstract void TryDeactivate(IActor actor);
}

public interface IObjectViev
{
    void ChangeColor(Color color);
}
