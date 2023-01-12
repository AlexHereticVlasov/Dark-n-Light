using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public sealed class Score : MonoBehaviour
{
    private readonly int _startValue = 100;
    private readonly WaitForSeconds _delay = new WaitForSeconds(1);

    [Inject] private Victory _victory;

    private int _value;
    private bool _isGameOver;

    public event UnityAction<int> ValueChanged;

    private void Start()
    {
        _value = _startValue;
        ValueChanged?.Invoke(_value);
        StartCoroutine(CountTime());
    }

    private void OnEnable() => _victory.Win += OnWin;

    private void OnDisable() => _victory.Win -= OnWin;

    private void OnWin() => _isGameOver = true;

    private IEnumerator CountTime()
    {
        while (_isGameOver == false)
        {
            yield return _delay;

            if (_value > 0)
            {
                _value--;
                ValueChanged?.Invoke(_value);
            }
        }
    }

    public void Add(BaseCollectable collectable)
    {
        _value += collectable.Cost; ;
        ValueChanged?.Invoke(_value);
    }
}
