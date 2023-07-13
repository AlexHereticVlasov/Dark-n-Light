using UnityEngine;


namespace FailTrigger
{
    public class FailVoice : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;

        public void Speak()
        {
            _source.PlayOneShot(_clip);
        }
    }
}