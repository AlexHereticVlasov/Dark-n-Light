using UnityEngine;

public sealed class HardModeLauncher : MonoBehaviour, IHardModeLauncher
{
    //ToDo: May be many effects
    [SerializeField] private HardModeAdapter _adapter;

    public void Cancel() => _adapter?.Cancel();

    public void Launch()
    {
        //Hack: Debug only
        if (_adapter is null)
        {
            Debug.LogError($"Current Level not containes {nameof(HardModeAdapter)}");
            return;
        }

        _adapter?.Launch();
    }
}
