using UnityEngine;
using UnityEngine.Events;

public class RayHost : MonoBehaviour
{
    private int _raysAmount = 0;

    public event UnityAction Activated;
    public event UnityAction Deactivated;

    public bool IsActive => _raysAmount > 0;


    public void Activate() 
    {
        _raysAmount++;
        //IsActive = true;
        Activated?.Invoke();
    }

    public void Deactivate() 
    {
        _raysAmount--;
        //IsActive = false;
        Deactivated?.Invoke();
    }
}
