using UnityEngine;

public sealed class Parallax : MonoBehaviour
{
    [Header("Scrolling Settings")]
    [SerializeField] private float _backGroundSize;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float _vievZone;

    [Header("Parallax Settings")]
    [SerializeField] private float _parallaxSpeed = default;
    [SerializeField] private float _yOffset = 1;

    private int _leftIndex;
    private int _rightIndex;
    private float _lastCameraX;

    private Vector3 _tempPosition = Vector3.zero;

    private void Start()
    {
        _lastCameraX = _cameraTransform.position.x;

        _leftIndex = 0;
        _rightIndex = _layers.Length - 1;
    }

    private void LateUpdate()
    {
        float _deltaX = _cameraTransform.position.x - _lastCameraX;

        _tempPosition.Set(
            transform.position.x + (_deltaX * _parallaxSpeed),
            _cameraTransform.position.y - _yOffset,
                                transform.position.z);

        transform.position = _tempPosition;

        _lastCameraX = _cameraTransform.position.x;

        if (_cameraTransform.position.x < _layers[_leftIndex].position.x + _vievZone)
            ScrollLeft();
        if (_cameraTransform.position.x > _layers[_rightIndex].position.x - _vievZone)
            ScrollRight();
    }

    private void ScrollLeft()
    {
        _layers[_rightIndex].position = new Vector3(_layers[_rightIndex].position.x - _backGroundSize,
                                                    transform.position.y,
                                                    transform.position.z);

        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
            _rightIndex = _layers.Length - 1;
    }

    private void ScrollRight()
    {
        _layers[_leftIndex].position = new Vector3(_layers[_rightIndex].position.x + _backGroundSize,
                                                   transform.position.y,
                                                   transform.position.z);

        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex == _layers.Length)
            _leftIndex = 0;
    }
}