using UnityEngine;

namespace PopUp
{
    public interface IPopUp
    {
        void Spawn(Vector2 position, Message message);
    }
}