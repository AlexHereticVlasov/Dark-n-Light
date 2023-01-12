using Cinemachine;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CameraSharer
{
    public sealed class CameraShake : MonoBehaviour
    {
        private const float Intencity = 1.5f;
        private const float Length = 0.5f;

        [Inject] private CinemachineVirtualCamera _virtualCamera = default;

        public void StartShake() => StartShake(Intencity, Length);

        public void StartShake(float intencity, float length) => StartCoroutine(Shake(intencity, length));

        private IEnumerator Shake(float intencity, float length)
        {
            var perlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = intencity;

            yield return DecreaseIntencity(perlin, intencity, length);

            perlin.m_AmplitudeGain = 0;
        }

        private IEnumerator DecreaseIntencity(CinemachineBasicMultiChannelPerlin perlin, float intencity, float length)
        {
            float totalTime = length;
            float time;

            while (length > 0)
            {
                length -= Time.deltaTime;
                time = length / totalTime;
                perlin.m_AmplitudeGain = Mathf.Lerp(intencity, 0, time);
                yield return null;
            }
        }
    }
}
