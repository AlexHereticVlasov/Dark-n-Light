using System;
using UnityEngine;

public class Observation : MonoBehaviour
{
    [SerializeField] private GroundCheckPoint[] _groundCheckPoints;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _blockMask;

    private int _facingDirection = 1;

    public float Direction { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsInteract { get; private set; }

    public void SetDirection(float direction)
    {
        if (IsNeedToFlip(direction))
            Flip();

        Direction = direction;
    }
    
    private bool IsNeedToFlip(float direction) => direction != 0 && Mathf.Sign(direction) != _facingDirection;


    //TODO: Think about remove this method somewhere else
    private void Flip()
    {
        _facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
                                           transform.localScale.y);
    }

    internal void Change()
    {
        Direction = 0;
    }

    public void SetIsJumping(bool value) => IsJumping = value;

    public void SetIsInteract(bool value) => IsInteract = value;
    //TODO:Create new classes for RayCheck
    public bool IsOnEarth()
    {
        foreach (var point in _groundCheckPoints)
            if (Physics2D.Raycast(point.transform.position, Vector2.down, 0.5f, _groundMask))
                return true;

        return false;
    }

    public bool IsPooshing() => Physics2D.Raycast(transform.position, new Vector2(_facingDirection, 0), 0.55f, _blockMask);
}
