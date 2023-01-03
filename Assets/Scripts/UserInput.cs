using UnityEngine;
using UnityEngine.Events;

public sealed class UserInput : MonoBehaviour
{
    [SerializeField] private Observation[] _observation;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private PauseMenu _pause;

    private int _current;

    public event UnityAction<Player> CharacterSwithed;

    private void Update() => ReadInput();

    private void ReadInput()
    {
        float direction = Input.GetAxis("Horizontal");
        _observation[_current].SetDirection(direction);


        if (ShouldJump())
            TryJump();

        if (ShouldInteract())
            TryInteract();

        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchCharacter();

        if (Input.GetKeyDown(KeyCode.Escape))
            StayOnPause();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            _cameraFollow.ChangeView();
    }

    private bool ShouldInteract() => Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F);

    private bool ShouldJump() => Input.GetKeyDown(KeyCode.W) ||
                                 Input.GetKeyDown(KeyCode.UpArrow) ||
                                 Input.GetKeyDown(KeyCode.Space);

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
        CharacterSwithed?.Invoke(_observation[_current].GetComponent<Player>());
    }

    //ToDo:Remove to observations
    private bool CanInteract()
    {
        //ToDO: Masks and etc...
        var colliders = Physics2D.OverlapPointAll(_observation[_current].transform.position);
        foreach (var collider in colliders)
            if (collider.TryGetComponent(out IInteractable interactable))
                return true;

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
