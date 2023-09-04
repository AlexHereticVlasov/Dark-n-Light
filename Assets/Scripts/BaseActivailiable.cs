using UnityEngine;
using UnityEngine.Events;

public abstract class BaseActivailiable : MonoBehaviour
{
    public event UnityAction Activated;
    public event UnityAction Deactivated;

    public virtual void Activate() => Activated?.Invoke();

    public virtual void Deactivate() => Deactivated?.Invoke();
}

public sealed class BellOfDagon : BaseActivailiable
{
    [SerializeField] private Stalker _stalker;

    public override void Activate()
    {
        base.Activate();
        _stalker.StartHunt();
    }
}

[RequireComponent(typeof(BellOfDagon))]
public sealed class BellOfDagonView : MonoBehaviour
{
    [SerializeField] private BellOfDagon _bellOfDagon;

    private void OnEnable() => _bellOfDagon.Activated += OnActivated;

    private void OnDisable() => _bellOfDagon.Activated -= OnActivated;

    private void OnActivated()
    {
        
    }
}