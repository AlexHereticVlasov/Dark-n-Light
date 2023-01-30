using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class PopUp : MonoBehaviour
{
    [SerializeField] private PopUpMessage _template;

    public void Spawn(Vector2 position, Message message)
    {
        PopUpMessage popUpMessage = Instantiate(_template, position, Quaternion.identity);
        popUpMessage.Init(message);
    }
}
