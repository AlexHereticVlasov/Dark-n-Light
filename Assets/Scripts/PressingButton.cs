using System.Collections.Generic;

public class PressingButton : BaseButton
{
    private List<IActor> _actors = new List<IActor>();

    protected override void TryActivate(IActor actor)
    {
        _actors.Add(actor);
        if (_actors.Count == 1)
            Activate();
    }

    protected override void TryDeactivate(IActor actor)
    {
        _actors.Remove(actor);
        if (_actors.Count == 0)
            Deactivate();
    }
}
