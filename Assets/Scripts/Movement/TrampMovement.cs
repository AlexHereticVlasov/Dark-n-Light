using UnityEngine;

public class TrampMovement : BaseMovement
{
    [SerializeField] private Path _path;
    [SerializeField] private int _currentPoint;
    [SerializeField] private float _speed;
 
    protected override void Move()
    {
        float delta = Time.deltaTime * _speed;
        Vector2 target = _path.GetPoint(_currentPoint);
        transform.position = Vector2.MoveTowards(transform.position, target, delta);
        if (Vector2.Distance(transform.position, target) < delta)
        {
            transform.position = target;
            _currentPoint++;
            _currentPoint %= _path.Count;
        }
    }
}
