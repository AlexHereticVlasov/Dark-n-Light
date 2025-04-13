using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FullScreen
{
    public sealed class FullScreenShader : MonoBehaviour
    {
        //ToDo: Create FullScreenConfig SO
        [SerializeField] private float _displayTime;
        [SerializeField] private float _fadeInTime;
        [SerializeField] private float _fadeOutTime;

        [SerializeField] private float _intencity = 1.25f;
        [SerializeField] private float _voronoyIntencity = 2.5f;
        //
        [SerializeField] private ScriptableRendererFeature _feature;
        [SerializeField] private Material _material;

        private readonly int _voronoyIntencityID = Shader.PropertyToID("_VIntencity");
        private readonly int _vignetIntencityID = Shader.PropertyToID("_Intencity");

        private void Start() => _feature.SetActive(false);

        private void OnDisable() => _feature.SetActive(false);

        public void Play() => StartCoroutine(PlayRoutene());

        public void Stop() =>  StartCoroutine(StopRoutine());

        private IEnumerator PlayRoutene()
        {
            _feature.SetActive(true);

            float elapsedTime = 0;
            while (elapsedTime < _fadeInTime)
            {
                elapsedTime += Time.deltaTime;
                float normalizedTime = elapsedTime / _fadeInTime;

                SetParam(_voronoyIntencityID, normalizedTime, 0, _voronoyIntencity);
                SetParam(_vignetIntencityID, normalizedTime, 0, _intencity);

                yield return null;
            }
        }

        private IEnumerator StopRoutine()
        {
            float elapsedTime = 0;
            while (elapsedTime < _fadeOutTime)
            {
                elapsedTime += Time.deltaTime;
                float normalizedTime = elapsedTime / _fadeOutTime;

                SetParam(_voronoyIntencityID, normalizedTime, _voronoyIntencity, 0);
                SetParam(_vignetIntencityID, normalizedTime, _intencity, 0);

                yield return null;
            }

            _feature.SetActive(false);
        }

        private void SetParam(int ID, float normalizedTime, float start, float end)
        {
            float lerpedVignet = Mathf.Lerp(start, end, normalizedTime);
            _material.SetFloat(ID, lerpedVignet);
        }
    }
}