using UnityEngine;

public abstract class BasePoint : MonoBehaviour 
{
    public Vector2 Position => transform.position;
}
