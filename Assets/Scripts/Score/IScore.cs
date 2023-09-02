using UnityEngine.Events;

namespace Timer
{
    public interface IScore 
    {
        event UnityAction<int> ValueChanged;

        void Add(BaseCollectable collectable);
    }
}
