using UnityEngine;

public abstract class BaseSoundList : ScriptableObject
{
    [SerializeField] protected AudioClip[] Clips;
}
