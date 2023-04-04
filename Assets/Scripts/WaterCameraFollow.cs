using UnityEngine;
using Zenject;


public sealed class WaterCameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _waterCamera;

    [Inject] private CameraFollow _cameraFollow;
    [SerializeField] private Transform _viev;

    private float _y;
    private float _currentY;
    private float _z;
    private Vector3 _previousPosition;

    private void Awake()
    {
        _currentY = transform.position.y;
        _y = _currentY;
        _z = transform.position.z;
    }

    private void OnEnable() => _cameraFollow.SizeChanged += OnSizeChanged;

    private void OnDisable() => _cameraFollow.SizeChanged -= OnSizeChanged;

    private void OnSizeChanged(float size)
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float screenHeightInUnits = size * 2;
        float screenWidthInUnits = screenHeightInUnits * screenRatio;

        _viev.localScale = new Vector3(screenWidthInUnits, _viev.localScale.y);
        _waterCamera.orthographicSize = size;
        _currentY = _y - 5 + size;
    }

    private void Update()
    {
        if (Camera.main.transform.position != _previousPosition)
        {
            _previousPosition = Camera.main.transform.position;
            _waterCamera.transform.position = new Vector3(_previousPosition.x, _currentY, _z);
            ClampLocalPosition();
            transform.position = new Vector3(_previousPosition.x, _y, _z);
        }
    }

    private void ClampLocalPosition() => _waterCamera.transform.localPosition = new Vector3(0,
                                         _waterCamera.transform.localPosition.y,
                                         _waterCamera.transform.localPosition.z);
}
