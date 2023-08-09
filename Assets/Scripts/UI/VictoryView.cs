using UnityEngine;

public class VictoryView : MonoBehaviour
{
    
}

public interface IPopUp
{
    void Spawn(Vector2 position, Message message);
}

public sealed class PopUp : MonoBehaviour, IPopUp
{
    [SerializeField] private PopUpMessage _template;

    public void Spawn(Vector2 position, Message message)
    {
        PopUpMessage popUpMessage = Instantiate(_template, position, Quaternion.identity);
        popUpMessage.Init(message);
    }
}
