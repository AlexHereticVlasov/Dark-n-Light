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
        CheckIsDestinationReached(delta, target);
    }

    private void CheckIsDestinationReached(float delta, Vector2 target)
    {
        if (Vector2.Distance(transform.position, target) < delta)
            EndMovement(target);
    }

    private void EndMovement(Vector2 target)
    {
        transform.position = target;
        _currentPoint++;
        _currentPoint %= _path.Count;
    }
}
