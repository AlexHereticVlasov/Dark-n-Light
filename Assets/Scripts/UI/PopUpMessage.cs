using TMPro;
using UnityEngine;
using Pool;
using UnityEngine.Events;

namespace PopUp
{
    public class PopUpMessage : MonoBehaviour, IPooleable
    {
        private const float Lifetime = 5;

        private readonly float _speed = 1.5f;

        [SerializeField] private TMP_Text _text;

        public event UnityAction<IPooleable> UseageComplited;

        //ToDo: Add Font
        public void Init(Message messsage)
        {
            //_text.font =;
            _text.text = messsage.Text;
        }

        public void Reuse()
        {

        }

        private void Start() => Invoke(nameof(TurnOff), Lifetime);

        private void Update() => transform.Translate(Vector2.up * Time.deltaTime * _speed);

        private void TurnOff()
        {
            _text.text = string.Empty;
            UseageComplited?.Invoke(this);
        }
    }
}