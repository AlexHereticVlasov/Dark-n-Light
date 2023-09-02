using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Exit
{
    [field: SerializeField] public Elements Element { get; private set; }
    [field: SerializeField] public LevelEndExitEffect ExitEffect { get; private set; }
    [field: SerializeField] public LevelEndEnterEffect EnterEffect { get; private set; }
    
    public bool IsInside { get; private set; }

    public event UnityAction StateChanged;

    public void Init()
    {
        EnterEffect.PlayerInside += OnPlayerInside;
        ExitEffect.Playeroutside += OnPlayeroutside;
    }

    public void Disable()
    {
        EnterEffect.PlayerInside -= OnPlayerInside;
        ExitEffect.Playeroutside -= OnPlayeroutside;
    }

    private void OnPlayeroutside(Player player)
    {
        if (player.Element != Element) return;
        
        IsInside = false;
        StateChanged?.Invoke();
    }

    private void OnPlayerInside(Player player)
    {
        if (player.Element != Element) return;

        IsInside = true;
        StateChanged?.Invoke();
    }

    public void Warp(Vector2 position)
    {
        var colliders = Physics2D.OverlapCircleAll(position, 1.5f).Where(collider => collider.TryGetComponent(out Player p));
        Player player = null;
        foreach (var collider in colliders)
        {
            player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.Warp();
                return;
            }
        }
    }
}
