using UnityEngine;
using UnityEngine.Events;

public interface IVictory
{
    event UnityAction Win;
}

public class Victory : MonoBehaviour, IVictory
{
    [SerializeField] private EndZoneMediator _endZone;
    [SerializeField] private GameObject _victoryPanel;

    public event UnityAction Win;

    private void OnEnable() => _endZone.Victory += OnVictory;

    private void OnDisable() => _endZone.Victory -= OnVictory;

    private void OnVictory()
    {
        Win?.Invoke();
        Time.timeScale = 0;
        _victoryPanel.SetActive(true);
    }
}
