using UnityEngine;
using UnityEngine.Events;

public abstract class BaseActivailiable : MonoBehaviour
{
    public event UnityAction Activated;
    public event UnityAction Deactivated;

    public virtual void Activate() => Activated?.Invoke();

    public virtual void Deactivate() => Deactivated?.Invoke();
}
