using UnityEngine;
using UnityEngine.Events;

public sealed class RayHost : MonoBehaviour
{
    private int _raysAmount = 0;

    public event UnityAction Activated;
    public event UnityAction Deactivated;

    public bool IsActive => _raysAmount > 0;

    public void Activate() 
    {
        _raysAmount++;
        Activated?.Invoke();
    }

    public void Deactivate() 
    {
        _raysAmount--;
        Deactivated?.Invoke();
    }
}

public sealed class RayHostViev : MonoBehaviour, IObjectViev
{
    public void ChangeColor(Color color)
    {
        //ToDo: Realize class Logic
        throw new System.NotImplementedException();
    }
}
