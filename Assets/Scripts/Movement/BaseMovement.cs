using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    private void Update() => Move();

    protected abstract void Move();
}

public class DescendingMovement : BaseMovement
{
    //ToDo: States?
    private bool _hasChild = false;
    private bool _isInStartPoint = true;

    protected override void Move()
    {
        
    }
}
