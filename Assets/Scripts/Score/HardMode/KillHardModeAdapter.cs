using UnityEngine;

public sealed class KillHardModeAdapter : HardModeAdapter
{
    [SerializeField] private Player[] _players;

    public override void Cancel()
    {
        ;
    }

    public override void Launch()
    {
        foreach (var player in _players)
            player.TakeDamage(float.MaxValue);
    }
}
