using UnityEngine;

public sealed class UserInput : MonoBehaviour
{
    [SerializeField] private Observation[] _observation;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private PauseMenu _pause;

    private int _current;

    private void Update() => ReadInput();

    private void ReadInput()
    {
        float direction = Input.GetAxis("Horizontal");
        _observation[_current].SetDirection(direction);


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            TryJump();

        if (Input.GetKeyDown(KeyCode.Space))
            TryInteract();

        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchCharacter();

        if (Input.GetKeyDown(KeyCode.Escape))
            StayOnPause();
    }

    private void TryInteract()
    {
        if (CanInteract())
            _observation[_current].SetIsInteract(true);
    }

    private void TryJump()
    {
        if (_observation[_current].IsOnEarth())
            _observation[_current].SetIsJumping(true);
    }

    private void SwitchCharacter()
    {
        _observation[_current].Change();
        _current++;
        _current %= _observation.Length;
        _cameraFollow.ChangeTarget(_observation[_current].transform);
    }

    //Hack: Temp Solution, Cast overlap to find IInteractable object
    private bool CanInteract()
    {
        //ToDO: Masks and etc...
        var colliders = Physics2D.OverlapPointAll(_observation[_current].transform.position);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                return true;
            }
        }

        return false;
    }

    private void StayOnPause()
    {
        if (Time.timeScale == 0)
        {
            _pause.Continue();
        }
        else 
        {
            _pause.PauseGame();
        }
    }
}
