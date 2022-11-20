using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;

    public int Count => _wayPoints.Length;

    public Vector2 GetPoint(int index) => _wayPoints[index].transform.position;
}
