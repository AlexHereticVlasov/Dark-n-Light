using Runes;
using UnityEngine;
using UnityEngine.Events;

public sealed class RuneAltarZoneEffect : BaseZoneEffect
{
    [SerializeField] private int _cost = 3;
    [SerializeField] private BaseActivailiable _activailiable;

    private RuneStorage _runeStorage;
    private bool _isActivated;

    public event UnityAction Activated;

    public override void Apply(Player player)
    {
        if (_isActivated) return;

        if (_runeStorage.TryRemove(_cost))
        {
            Activated?.Invoke();
            _activailiable.Activate();
            _isActivated = true;
            return;
        }

        Debug.Log("Spawn Pop up Message (Not enough runes)" + player.transform.position + Vector2.up);
    }
}

