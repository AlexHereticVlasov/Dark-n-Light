﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class EndZoneMediator : MonoBehaviour
{
    [SerializeField] private Exit[] _exits;
    [SerializeField] private ElementBean _bean;

    private Coroutine _checkRoutine;
    private WaitForSeconds _delay = new WaitForSeconds(1.75f);

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

    public void Recolor()
    {
        foreach (var exit in _exits)
        {
            var view = exit.ExitEffect.GetComponent<LevelZoneView>();
            var colors = new Color[1];
            colors[0] = _bean[exit.Element].MainColor;
            view.Recolor(colors);
        }
    }

    private IEnumerator CheckForVictory()
    {
        yield return _delay;

        foreach (var exit in _exits)
            if (exit.IsInside == false)
                yield break;

        foreach (var exit in _exits)
            exit.Warp(exit.EnterEffect.transform.position);

        yield return _delay;
        Victory?.Invoke();
    }
}