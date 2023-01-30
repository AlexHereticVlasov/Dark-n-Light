using TMPro;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    private const float Lifetime = 5;

    private readonly float _speed = 1.5f;

    [SerializeField] private TMP_Text _text;

    //ToDo: Add Font
    public void Init(Message messsage)
    {
        //_text.font =;
        _text.text = messsage.Text;
    }

    private void Start() => Destroy(gameObject, Lifetime);

    private void Update() => transform.Translate(Vector2.up * Time.deltaTime * _speed);
}
