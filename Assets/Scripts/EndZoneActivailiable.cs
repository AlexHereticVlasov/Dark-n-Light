using UnityEngine;

public sealed class EndZoneActivailiable : BaseActivailiable
{
    [SerializeField] private bool _isActive = true;

    private void Start()
    {
        if (_isActive)
        {
            Activate();
            return;
        }

        Deactivate();
    }
}
