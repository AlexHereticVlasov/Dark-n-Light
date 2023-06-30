using UnityEngine;
using Zenject;

public sealed class WaterCameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _waterCamera;
    [SerializeField] private Transform _viev;

    [Inject] private CameraFollow _cameraFollow;

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

    private void Update()
    {
        if (IsSamePosition()) return;

        Follow();
    }

    private void OnDisable() => _cameraFollow.SizeChanged -= OnSizeChanged;

    private void OnSizeChanged(float size)
    {
        float screenWidthInUnits = CalculateWidthInUnits(size);
        _viev.localScale = new Vector3(screenWidthInUnits, _viev.localScale.y);
        _waterCamera.orthographicSize = size;
        _currentY = _y - 5 + size;
    }

    private bool IsSamePosition() => Camera.main.transform.position == _previousPosition;

    private void Follow()
    {
        _previousPosition = Camera.main.transform.position;
        _waterCamera.transform.position = new Vector3(_previousPosition.x, _currentY, _z);
        ClampLocalPosition();
        transform.position = new Vector3(_previousPosition.x, _y, _z);
    }

    private float CalculateWidthInUnits(float size)
    {
        float screenRatio = Screen.width / (float)Screen.height;
        float screenHeightInUnits = size * 2;
        return screenHeightInUnits * screenRatio;
    }

    private void ClampLocalPosition() => _waterCamera.transform.localPosition = new Vector3(0,
                                         _waterCamera.transform.localPosition.y,
                                         _waterCamera.transform.localPosition.z);
}
