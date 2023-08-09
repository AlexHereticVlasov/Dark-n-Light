﻿using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public sealed class PendulumMovement : BaseMovement
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _length;
    [SerializeField] private Transform _origin;
    [SerializeField] private Transform _bob;
    [SerializeField] private float _angle = 45;

    private float _angularVelocity;
    private float _angularAcseleration;
    private float _angleInRadians;

    private void Start()
    {
        _angleInRadians = _angle * Mathf.Deg2Rad;
        _lineRenderer.SetPosition(0, _origin.position);
    }

    protected override void Move()
    {
        float sin = Mathf.Sin(_angleInRadians);
        ApplyForce(sin);

        _bob.position = ResetPosition(sin);
        _lineRenderer.SetPosition(1, _bob.position);
    }

    private void ApplyForce(float sin)
    {
        float force = 0.000981f * sin;
        _angularAcseleration = force / _length;
        _angularVelocity += _angularAcseleration;
        _angleInRadians += _angularVelocity;
    }

    private Vector3 ResetPosition(float sin)
    {
        float bobX = _length * sin + _origin.position.x;
        float bobY = _length * Mathf.Cos(_angleInRadians) + _origin.position.y;
        return new Vector3(bobX, bobY, _bob.position.z);
    }

    public void CalculateLength(float time, int n)
    {
        float k = 16f;
        _length = 9.81f * Mathf.Pow(time / (2 * Mathf.PI * (k + n + 1)), 2);
        transform.position += Vector3.up * _length;
    }
}