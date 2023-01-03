using System.Collections;
using UnityEngine;
using Cinemachine;
using System;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float _maxSize = 15;
    [SerializeField] private float _minSize = 5;

    private Coroutine _zoomRoutine;
    private float factor;
    private float _target;

    public void ChangeTarget(Transform target) => _virtualCamera.Follow = target;

    public void ChangeView()
    {
        if (_zoomRoutine != null) return;

        float size = _virtualCamera.m_Lens.OrthographicSize;
        _zoomRoutine = StartCoroutine(size == _minSize ? Zoom(_maxSize, () => factor < _target, 10) :
                                                         Zoom(_minSize, () => factor > _target, -10));
    }

    private IEnumerator Zoom(float target, Func<bool> func, float speed)
    {
        _target = target;
        factor = _virtualCamera.m_Lens.OrthographicSize;
        while (func())
        {
            yield return null;
            factor += Time.deltaTime * speed;
            _virtualCamera.m_Lens.OrthographicSize = factor;
        }

        _virtualCamera.m_Lens.OrthographicSize = target;
        _zoomRoutine = null;
    }
}