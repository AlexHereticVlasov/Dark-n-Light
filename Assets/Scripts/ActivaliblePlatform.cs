﻿using System.Collections;
using UnityEngine;

public class ActivaliblePlatform : BaseActivailiable
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 4;

    private int _curentPoint;
    private Coroutine _activationRoutine;


    public override void Activate()
    {
        base.Activate();
        if (_activationRoutine != null)
            StopCoroutine(_activationRoutine);

        _activationRoutine = StartCoroutine(ChangeState());
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (_activationRoutine != null)
            StopCoroutine(_activationRoutine);

        _activationRoutine = StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        //ToDo:Dry
        //Undone: Something wrong with size of check area
        //ToDo: Need to add movement Check to avoid collision with dynamic objects
        var colliders = Physics2D.OverlapBoxAll(transform.position, transform.GetChild(0).localScale, 0); //ToDo: Add Mask
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IPhysicMovement physicMovement))
            {
                physicMovement.Freaze();
                physicMovement.SetParent(transform);
            }
        }

        _curentPoint++;
        _curentPoint %= _path.Count;
        Vector2 target = _path.GetPoint(_curentPoint);

        while (Vector2.Distance(transform.position, target) > Time.deltaTime * _speed)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * _speed);
            yield return null;
        }

        transform.position = target;
        _activationRoutine = null;

        colliders = Physics2D.OverlapBoxAll(transform.position, transform.GetChild(0).localScale, 0); //ToDo: Add Mask
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IPhysicMovement physicMovement))
            {
                physicMovement.Restore();
                physicMovement.SetParent(null);
            }
        }
    }
}