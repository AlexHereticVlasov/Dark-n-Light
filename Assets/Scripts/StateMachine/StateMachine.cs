using UnityEngine;

namespace FinalStateMachine
{
    public class StateMachine
    {
        public BaseState Current { get; private set; }

        public void Init(BaseState state)
        {
            Current = state;
            Current.Enter();
        }

        public void ChangeState(BaseState state)
        {
            Current.Exit();
            Current = state;
            Current.Enter();
        }
    }

    public abstract class BaseState
    {
        public virtual void Enter()
        {
            //Debug.Log($"Enter {this}");
            //ToDo: Start Animation Here
        }

        public abstract void Update();

        public virtual void Exit()
        {
            //Debug.Log(nameof(Exit));
            //ToDo: EndAnimation
        }
    }

    public abstract class BaseCharacterState : BaseState
    {
        protected Observation _observation;
        protected StateMachine _stateMachine;
        protected Player _player;

        public BaseCharacterState(Observation observation, StateMachine machine, Player player)
        {
            _observation = observation;
            _stateMachine = machine;
            _player = player;
        }

    }

    public abstract class LevitationState : BaseCharacterState
    {
        protected PlayerMovement _movement;

        protected LevitationState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player)
        {
            _movement = movement;
        }
    }

    public class IdleLevitationState : LevitationState
    {
        public IdleLevitationState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Update()
        {
            //base.Update();
            if (_observation.Direction != 0)
            {
                _stateMachine.ChangeState(_player.MoveLevitationState);
            }

            _movement.SetXVelocity(0);
        }
    }

    public class MoveLevitationState : LevitationState
    {
        public MoveLevitationState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Update()
        {
            if (_observation.Direction == 0)
                _stateMachine.ChangeState(_player.IdleLevitationState);

            _movement.SetXVelocityInAir(_observation.Direction);
        }
    }

    public abstract class OnGroundState : BaseCharacterState
    {
        protected PlayerMovement _movement;

        protected OnGroundState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player)
        {
            _movement = movement;
        }

        public override void Update()
        {
            if (_observation.IsOnEarth() == false)
            {
                _stateMachine.ChangeState(_player.InAirState);
                _observation.ResetCayotityTime();
            }

            if (_observation.IsJumping)
            {
                _observation.SetIsJumping(false);
                _stateMachine.ChangeState(_player.StartJumpState);
            }
            else if (_observation.IsInteract)
            {
                _observation.SetIsInteract(false);
                _stateMachine.ChangeState(_player.InteractionState);
            }
        }
    }
    public class IdleState : OnGroundState
    {
        public IdleState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Update()
        {
            base.Update();
            if (_observation.Direction != 0)
            {
                _stateMachine.ChangeState(_player.WalkState);
            }

            _movement.SetXVelocity(0);
        }
    }

    public class WalkState : OnGroundState
    {
        public WalkState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Update()
        {
            base.Update();
            if (_observation.Direction == 0)
                _stateMachine.ChangeState(_player.IdleState);

            _movement.SetXVelocity(_observation.Direction);

            if (_observation.IsPooshing())
                _stateMachine.ChangeState(_player.PushState);
        }
    }
    public abstract class JumpState : BaseCharacterState
    {
        protected JumpState(Observation observation, StateMachine machine, Player player) : base(observation, machine, player)
        {
        }
    }

    public class StartJumpState : JumpState
    {
        private PlayerMovement _movement;
        private float _delay;

        public StartJumpState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player)
        {
            _movement = movement;
        }

        public override void Enter()
        {
            //ToDo:Remove constants to player Config
            base.Enter();
            _movement.Jump(310);
            _delay = .25f;
        }

        public override void Update()
        {
            if (_observation.IsOnEarth() == false) // ToDo: Use Polymorph
                _stateMachine.ChangeState(_player.InAirState);

            _delay -= Time.deltaTime;
            if (_delay <= 0)
                _stateMachine.ChangeState(_player.IdleState);
        }
    }

    public class InAirState : JumpState
    {
        public InAirState(Observation observation, StateMachine machine, Player player) : base(observation, machine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            //ToDO: Move in Air?
            if (_observation.IsJumping)
            {
                _observation.SetIsJumping(false);
                if (_observation.CayotityTime.CanJump())
                {
                    _stateMachine.ChangeState(_player.StartJumpState);
                    _observation.CayotityTime.SetValue(0);
                }
            }

            if (_observation.IsOnEarth())
                _stateMachine.ChangeState(_player.LandingState);
        }
    }
    public class LandingState : JumpState
    {
        public LandingState(Observation observation, StateMachine machine, Player player) : base(observation, machine, player)
        {
        }

        public override void Update()
        {
            if (_observation.IsOnEarth())
                _stateMachine.ChangeState(_player.IdleState);
        }
    }

    public class InteractionState : OnGroundState
    {
        private float _length;
        private IInteractable _interactable;

        public InteractionState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //Hack: Temp Solituon, get length from animation
            _length = 0.5f;

            var colliders = Physics2D.OverlapCircleAll(_player.transform.position, Constants.InteractionRadius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    _interactable = interactable;
                    return;
                }
            }

            Debug.LogWarning("Interactable == null");
            _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Update()
        {
            base.Update();
            _length -= Time.deltaTime;
            if (_length <= 0)
            {
                _interactable.Interact();
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }

    public class PushState : OnGroundState
    {
        public PushState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player, movement)
        {
        }

        public override void Update()
        {
            base.Update();
            _movement.SetXVelocity(_observation.Direction);

            if (_observation.IsPooshing() == false)
            {
                //ToDo: Different Cases
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }

    public class DeathState : BaseCharacterState
    {
        private PlayerMovement _movement;

        public DeathState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player)
        {
            _movement = movement;
        }

        public override void Enter()
        {
            base.Enter();
            _movement.SetXVelocity(0);
            _movement.Freaze();
        }

        public override void Update()
        {
            ;
        }
    }

    public class LevelCompliteState : BaseCharacterState
    {
        PlayerMovement _movement;
        private Transform _destination;
        private float _factor;
        private bool _isComplited;

        public LevelCompliteState(Observation observation, StateMachine machine, Player player, PlayerMovement movement) : base(observation, machine, player)
        {
            _movement = movement;
        }

        public override void Enter()
        {
            base.Enter();
            _factor = 0;
            _destination = _observation.GetDestinaton();
            _movement.Freaze();
        }

        public override void Update()
        {
            if (_isComplited) return;

            if (_factor < 1)
            {
                _player.transform.position = Vector2.Lerp(_player.transform.position, _destination.position, _factor);
                _player.transform.localScale = Vector2.one * (1 - _factor) * 0.9f;
                _factor += Time.deltaTime * 1.5f;
                _factor = Mathf.Clamp01(_factor);
                return;
            }

            _isComplited = true;
            Debug.Log("SpawnFX");
        }
    }
}