using UnityEngine;

public class RotatingMirror : MonoBehaviour
{
    //ToDo: Fix this class name

    [SerializeField] private Liver _liver;

    private void OnEnable() => _liver.PositionChanged += OnPositionChanged;

    private void Start()
    {
        float z = transform.rotation.eulerAngles.z;
        _liver.SetPosition(z / 180);
    }

    private void OnDisable() => _liver.PositionChanged -= OnPositionChanged;

    private void OnPositionChanged(float value)
    {
        //ToDo: Fix this logic
        transform.rotation = Quaternion.Euler(0, 0, value * 180);
    }
}
