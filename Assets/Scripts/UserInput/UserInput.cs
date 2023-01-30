using UnityEngine;
using UnityEngine.Events;
using Zenject;

public sealed class UserInput : BaseUserInput
{
    [SerializeField] private Observation[] _observation;

    [Inject] private PauseMenu _pause;
    [Inject] private CameraFollow _cameraFollow;
    
    private int _current;

    public event UnityAction<Player> CharacterSwithed;

    private void Start()
    {
        for (int i = 0; i < _observation.Length; i++)
        {
            var player = _observation[i].GetComponent<Player>();
            if (i == _current)
            {
                player.Select();
                continue;
            }

            player.Deselect();
        }
    }

    protected override void ReadInput()
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
        if (_observation[_current].CanInteract())
            _observation[_current].SetIsInteract(true);
    }

    private void TryJump()
    {
        if (_observation[_current].CanJump())
            _observation[_current].SetIsJumping(true);
    }

    private void SwitchCharacter()
    {
        _observation[_current].Change();
        var previous = _observation[_current].GetComponent<Player>();
        previous.Deselect();

        _current++;
        _current %= _observation.Length;
        _cameraFollow.ChangeTarget(_observation[_current].transform);
        var player = _observation[_current].GetComponent<Player>();
        CharacterSwithed?.Invoke(player);
        player.Select();
    }

    //ToDo:Remove to observations
    

    private void StayOnPause()
    {
        if (Time.timeScale == 0)
            _pause.Continue();
        else 
            _pause.PauseGame();
    }
}
