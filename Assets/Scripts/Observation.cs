using UnityEngine;

public class Observation : MonoBehaviour
{
    [SerializeField] private GroundCheckPoint[] _groundCheckPoints;
    [SerializeField] private LayerMask _groundMask;

    public float Direction { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsInteract { get; private set; }

    internal void SetDirection(float direction) => Direction = direction;

    internal void SetIsJumping(bool value) => IsJumping = value;

    internal void SetIsInteract(bool value) => IsInteract = value;

    public bool IsOnEarth()
    {
        foreach (var point in _groundCheckPoints)
        {
            if (Physics2D.Raycast(point.transform.position, Vector2.down, 0.5f, _groundMask))
            {
                return true;
            }
        }

        return false;
        //return Physics2D.Raycast(transform.position, Vector2.down, 0.50f, _groundMask);

    }
}
