using UnityEngine;

public class StalkerMovement : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 2;

    public void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
