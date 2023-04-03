using System;
using System.Collections;
using UnityEngine;

public sealed class RotatableMirror : BaseActivailiable
{
    [SerializeField, Range(0, 360)] private float _angle;
    [SerializeField] private float _rotationSpeed = 90;

    private Coroutine _rotationRoutine;

    public override void Activate()
    {
        base.Activate();
        if (_rotationRoutine == null)
            _rotationRoutine = StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        float angle = _angle;
        while (angle > 0)
        {
            float delta = _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.back, delta);
            angle -= delta;

            yield return null;
        }

        transform.Rotate(Vector3.back, angle);

        _rotationRoutine = null;
    }
}
