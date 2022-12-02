using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EndZoneMediator : MonoBehaviour
{
    [SerializeField] private Exit[] _exits;

    private Coroutine _checkRoutine;

    public event UnityAction Victory;

    private void OnEnable()
    {
        foreach (var exit in _exits)
        {
            exit.Init();
            exit.StateChanged += OnStateChanged;
        }
    }


    private void OnDisable()
    {
        foreach (var exit in _exits)
        {
            exit.Disable();
            exit.StateChanged -= OnStateChanged;
        }

    }

    private void OnStateChanged()
    {
        foreach (var exit in _exits)
        {
            if (exit.IsInside == false)
            {
                if (_checkRoutine != null)
                    StopCoroutine(_checkRoutine);
                
                return;
            }
        }

        _checkRoutine = StartCoroutine(CheckForVictory());

    }

    private IEnumerator CheckForVictory()
    {
        Debug.Log("StartCheck");

        yield return new WaitForSeconds(3);
        
        foreach (var exit in _exits)
            if (exit.IsInside == false)
                yield break;

        Victory?.Invoke();
        Debug.Log("Victory");
    }
}