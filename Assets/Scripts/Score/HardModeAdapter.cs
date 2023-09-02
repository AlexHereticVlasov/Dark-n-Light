using UnityEngine;

[RequireComponent(typeof(HardModeLauncher))]
public abstract class HardModeAdapter : MonoBehaviour
{
    public abstract void Cancel();

    public abstract void Launch();    
}
