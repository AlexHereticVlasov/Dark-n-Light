using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    private void FixedUpdate() => Move();

    protected abstract void Move();
}
