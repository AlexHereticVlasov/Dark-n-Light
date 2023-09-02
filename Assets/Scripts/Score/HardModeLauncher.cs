using UnityEngine;

public sealed class HardModeLauncher : MonoBehaviour, IHardModeLauncher
{
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
