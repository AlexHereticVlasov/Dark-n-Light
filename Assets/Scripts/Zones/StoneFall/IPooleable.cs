using UnityEngine.Events;

namespace Pool
{
    public interface IPooleable
    {
        event UnityAction<IPooleable> UseageComplited;

        void Reuse();
    }
}
