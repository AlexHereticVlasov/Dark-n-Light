using Pool;
using UnityEngine;

namespace PopUp
{
    public sealed class PopUpFabric : MonoBehaviour, IPopUp
    {
        [SerializeField] private PopUpMessage _template;

        private ObjectPool<PopUpMessage> _pool;

        private void Start() => _pool = new ObjectPool<PopUpMessage>(_template);

        public void Spawn(Vector2 position, Message message)
        {
            var popUpMessage = _pool.Get();
            popUpMessage.transform.position = position;
            popUpMessage.Init(message);
        }
    }
}