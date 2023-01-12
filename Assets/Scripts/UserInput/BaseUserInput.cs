using UnityEngine;

public abstract class BaseUserInput : MonoBehaviour
{
    private void Update() => ReadInput();
    protected abstract void ReadInput();
}
