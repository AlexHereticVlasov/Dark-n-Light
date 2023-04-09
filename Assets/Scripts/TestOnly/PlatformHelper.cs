using UnityEngine;

public class PlatformHelper : Platform
{
    private readonly Vector3 _offset = Vector3.up * 0.25f;

    [SerializeField] private Transform _target;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Update()
    {
        transform.position = _target.position + _offset;
        _lineRenderer.SetPosition(1, transform.position);    
    }
}
