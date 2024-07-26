using System.Collections;
using UnityEngine;

namespace StoneFall
{
    [RequireComponent(typeof(StoneFallPoint))]
    public sealed class StoneFallPointView : MonoBehaviour
    {
        [SerializeField] private StoneFallPoint _point;
        [SerializeField] private SpriteRenderer _renderer;

        private readonly WaitForSeconds _delay = new WaitForSeconds(0.5f);

        private void OnEnable() => _point.Attention += OnAttention;

        private void OnDisable() => _point.Attention -= OnAttention;

        private void OnAttention() => StartCoroutine(ShowAttention());

        //Hack:Temp Solution, play particles System
        private IEnumerator ShowAttention()
        {
            _renderer.enabled = true;
            yield return _delay;
            _renderer.enabled = false;
        }
    }
}