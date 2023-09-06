using UnityEngine.Events;

namespace Timer
{
    public interface IHardModeCounter
    {
        event UnityAction TimeIsOwer;
        event UnityAction TimeRestored;
    }
}
