using System;
using UnityEngine;

public class Observation : MonoBehaviour
{
    private const float Radius = 0.5f;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundCheckPoint[] _groundCheckPoints;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _blockMask;
    [SerializeField] private LayerMask _interactableMask;
    //private int _facingDirection = 1;

    [field:SerializeField] public CoyotityTime CayotityTime { get; private set; }

    public float Direction { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsInteract { get; private set; }
    public bool IsOnIce { get; private set; }
    //ToDo: Create Warp Counter
    public bool IsWarp { get; private set; }
    public float YVelocity => _rigidbody.velocity.y;

    public void SetDirection(float direction)
    {
        if (IsNeedToFlip(direction))
            Flip();

        Direction = direction;
    }
    
    private bool IsNeedToFlip(float direction) => direction != 0 &&
        Mathf.Sign(direction) != Mathf.Sign(transform.localScale.x) /*_facingDirection*/;

    private void Flip() => transform.localScale = new Vector3(transform.localScale.x * -1,
                                                              transform.localScale.y);

    public void Stop() => Direction = 0;

    public void SetIsJumping(bool value) => IsJumping = value;

    public void SetIsInteract(bool value) => IsInteract = value;

    public void SetIsWarp(bool value) => IsWarp = value;

    //TODO:Create new classes for RayCheck
    public bool IsOnEarth()
    {
        foreach (var point in _groundCheckPoints)
            if (Physics2D.Raycast(point.transform.position, Vector2.down, Radius, _groundMask))
                return true;

        return false;
    }

    public bool IsPooshing() => Physics2D.Raycast(transform.position, new Vector2(/*_facingDirection*/ 
                                transform.localScale.x, 0), 0.55f, _blockMask);

    public Transform GetDestinaton()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (var collider in colliders)
            if (collider.TryGetComponent(out LevelEndExitEffect effect))
                return effect.transform;

        throw new Exception("No ExitZone");
    }

    public bool CanJump() => IsOnEarth() || CayotityTime.CanJump();

    public void ResetCayotityTime() => CayotityTime.ResetValue();

    public bool CanInteract()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Constants.InteractionRadius, _interactableMask);
        foreach (var collider in colliders)
            if (collider.TryGetComponent(out IInteractable interactable))
                return true;

        return false;
    }

    public void SetIsOnIce(bool value) => IsOnIce = value;
}

public class RayCheck : MonoBehaviour
{
    [SerializeField] private GroundCheckPoint[] _groundCheckPoints;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _blockMask;
    [SerializeField] private LayerMask _interactableMask;

    public bool IsOnEarth()
    {
        foreach (var point in _groundCheckPoints)
            if (Physics2D.Raycast(point.transform.position, Vector2.down, 0.5f, _groundMask))
                return true;

        return false;
    }

    public bool IsPooshing(int direction) => Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.55f, _blockMask);

    private bool CanInteract()
    {
        //ToDO: Masks and etc...
        var colliders = Physics2D.OverlapPointAll(transform.position, _interactableMask);
        foreach (var collider in colliders)
            if (collider.TryGetComponent(out IInteractable interactable))
                return true;

        return false;
    }

    public void TryInteract()
    {

    }
}