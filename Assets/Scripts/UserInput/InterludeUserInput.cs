using UnityEngine;
using Zenject;

public sealed class InterludeUserInput : BaseUserInput
{
    [Inject] private ISlideShow _slideShow;

    protected override void ReadInput()
    {
        if (Input.anyKey)
            _slideShow.Skip();
    }
}
