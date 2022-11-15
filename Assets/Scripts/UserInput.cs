using UnityEngine;

public sealed class UserInput : MonoBehaviour
{
    [SerializeField] private Observation _observation;

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        float direction = Input.GetAxis("Horizontal");
        _observation.SetDirection(direction);


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_observation.IsOnEarth())
            {
                _observation.SetIsJumping(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanInteract())
            {
                _observation.SetIsInteract(true);
            }
        }
    }

    //Hack: Temp Solution, Cast overlap to find IInteractable object
    private bool CanInteract()
    {
        return true;
    }
}
