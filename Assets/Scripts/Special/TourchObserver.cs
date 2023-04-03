using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Special
{
    public class TourchObserver : MonoBehaviour
    {
        [SerializeField] private Tourch[] _tourches;

        private void OnEnable()
        {
            foreach (var tourch in _tourches)
                tourch.Activated += OnActivated;
        }

        private void OnDisable()
        {
            foreach (var tourch in _tourches)
                tourch.Activated -= OnActivated;
        }

        private void OnActivated()
        {
            //ToDo:Spawn message about that "The tourch was blazed and hope was is Gone..."
        }
    }
}
