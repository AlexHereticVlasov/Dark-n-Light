using System.Collections;
using UnityEngine;

public class TimeButton : BaseButton
{
    [SerializeField] private int _totalTimer;
    
    private int _currentTimer;
    private WaitForSeconds _delay = new WaitForSeconds(1);

    protected override void Activate()
    {
        base.Activate();
        StartCoroutine(DeactivateRoutine());
    }

    protected override void TryActivate(IActor actor)
    {
        Activate();
    }

    protected override void TryDeactivate(IActor actor)
    {
        ;
    }

    private IEnumerator DeactivateRoutine()
    {
        _currentTimer = _totalTimer;

        while (_currentTimer > 0)
        {
            yield return _delay;
            _currentTimer--;
        }

        Deactivate();
    }
}
