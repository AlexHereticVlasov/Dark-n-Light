using UnityEngine;
using PopUp;
using Zenject;

namespace Special
{
    public class TourchObserver : MonoBehaviour
    {
        [SerializeField] private Tourch[] _tourches;
        [Inject] private IPopUp _popUp;
        [SerializeField] private Message _message;


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
            //ToDo:Spawn message about that "The torch has been lit and the hope is lost and gone."
            _popUp.Spawn(transform.position, _message);
        }
    }
}
