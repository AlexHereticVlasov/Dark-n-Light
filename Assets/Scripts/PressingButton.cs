using System.Collections.Generic;
using UnityEngine;

public class PressingButton : MonoBehaviour
{
    //ToDo: Inverse dependency by observer
    [SerializeField] private BaseActivailiable[] _activailiables;

    private List<IActor> _actors = new List<IActor>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IActor actor))
        {
            _actors.Add(actor);
            if (_actors.Count == 1)
                foreach (var activailiable in _activailiables)
                    activailiable.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IActor actor))
        {
            _actors.Remove(actor);
            if (_actors.Count == 0)
                foreach(var activailiable in _activailiables)
                    activailiable.Deactivate();
        }
    }
}
