using UnityEngine;

public sealed class HardModeLauncher : MonoBehaviour, IHardModeLauncher
{
    //ToDo: May be many effects
    [SerializeField] private HardModeAdapter _adapter;

    public void Cancel()
    {
        Debug.Log("Restored");
        _adapter.Cancel();
    }

    public void Launch()
    {
        Debug.Log("Over");
        _adapter.Launch();
    }
}
