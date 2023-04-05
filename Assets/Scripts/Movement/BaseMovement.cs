using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    private void Update() => Move();

    protected abstract void Move();
}
