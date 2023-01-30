using UnityEngine;

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
