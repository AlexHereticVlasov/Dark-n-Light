using UnityEngine;

public class FloatingPlatform : Platform
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 2;
    private bool _hasChild;

    private void Update()
    {
        Vector2 target = _path.GetPoint(_hasChild ? 0 : 1);
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * _speed);
    }

    protected override void Parent(Player player)
    {
        base.Parent(player);
        _hasChild = true;
    }

    protected override void Unparent(Player player)
    {
        base.Unparent(player);
        _hasChild = false;
    }
}
