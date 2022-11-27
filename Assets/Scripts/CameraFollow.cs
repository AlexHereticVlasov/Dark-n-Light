using UnityEngine;
using Cinemachine;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    public void ChangeTarget(Transform target) => _virtualCamera.Follow = target;
}