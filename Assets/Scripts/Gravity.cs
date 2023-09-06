using UnityEngine;
using UnityEngine.Events;

public interface IGravity
{
    public event UnityAction Reversed;

    void Reverse();
}

public sealed class Gravity : MonoBehaviour, IGravity
{
    public event UnityAction Reversed;

    //Hack: Temp Solution
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Reverse();
    }

    public void Reverse()
    {
        Physics2D.gravity *= -1;
        Reversed?.Invoke();
    }

    //Undone: Refactoring!!
    //private void ReverseGravity()
    //{
    //    Physics2D.gravity *= -1;
    //    var m = FindObjectsOfType<PlayerMovement>();

    //    Debug.Log(m.Length);
    //    foreach (var p in m)
    //    {
    //        p.SetJumpDirection(-Physics2D.gravity.normalized);
    //    }
    //}
}
