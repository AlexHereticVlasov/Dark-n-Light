using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Lose : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    [SerializeField] private GameObject _panel;

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

    private void OnDeath() => StartCoroutine(Die());

    private IEnumerator Die()
    {
        Defeate?.Invoke();
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        _panel.SetActive(true);
    }
}
