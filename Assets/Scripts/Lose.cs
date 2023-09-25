using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public interface ILose
{
    event UnityAction Defeate;
}

public sealed class Lose : MonoBehaviour, ILose
{
    [SerializeField] private Player[] _players;
    [SerializeField] private GameObject _panel;

    private WaitForSeconds _delay = new WaitForSeconds(1);

    public event UnityAction Defeate;

    private void OnEnable()
    {
        foreach (var player in _players)
            player.Death += OnDeath;
    }

    private void OnDisable()
    {
        foreach (var player in _players)
            player.Death -= OnDeath;
    }

    //ToDo: Invoke Event to fix camera on Dead Player;
    private void OnDeath(Vector2 position) => StartCoroutine(Die());

    private IEnumerator Die()
    {
        Defeate?.Invoke();
        yield return _delay;
        Time.timeScale = 0;
        _panel.SetActive(true);
    }
}
