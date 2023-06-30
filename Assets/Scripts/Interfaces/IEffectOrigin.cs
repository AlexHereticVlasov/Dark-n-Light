using UnityEngine;
using UnityEngine.Events;

public interface IEffectOrigin
{
    event UnityAction<Elements, Vector2> Spawned;
}
