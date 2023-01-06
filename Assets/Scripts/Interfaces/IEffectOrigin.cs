using UnityEngine.Events;

public interface IEffectOrigin
{
    event UnityAction<Elements> Spawned;
}
