using FinalStateMachine;
using System;
using UnityEngine;

public sealed class StalkerHardModeAdapter : HardModeAdapter
{
    [SerializeField] private Stalker _stalker;

    public override void Cancel() => _stalker.ReturnToSleep();

    public override void Launch() => _stalker.StartHunt();
}

public sealed class Stalker : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
    }

    public void ReturnToSleep()
    {
        throw new NotImplementedException();
    }

    public void StartHunt()
    {
        throw new NotImplementedException();
    }
}

namespace FinalStateMachine
{
    public abstract class BaseStalkerState : BaseState
    {

    }

    public sealed class SleapStalkerState : BaseStalkerState
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MoveToNestStalkerState : BaseStalkerState
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class TrampStalkerState : BaseStalkerState
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
    public sealed class FollowStalkerState : BaseStalkerState
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}