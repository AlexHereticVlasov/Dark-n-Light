using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class Score : MonoBehaviour
{
    private readonly int _startValue = 100;

    private int _value;
    private WaitForSeconds _delay = new WaitForSeconds(1);

    public event UnityAction<int> ValueChanged;

    private void Start()
    {
        _value = _startValue;
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        while (_value > 0)
        {
            yield return _delay;
            _value--;
            ValueChanged?.Invoke(_value);
        }
    }

    //ToDo: Subscribe on collection event
}
