using CameraShaker;
using System.Collections;
using UnityEngine;

namespace StoneFall
{
    [System.Serializable]
    public sealed class FallingStoneFabric
    {
        [SerializeField] private FallingStone _template;
        [SerializeField] private StoneFallPoint[] _points;
        [SerializeField] private int _cyclesAmmount = 4;

        private System.Func<IEnumerator, Coroutine> _corutine;
        private ICameraShake _cameraShake;

        public void Init(System.Func<IEnumerator, Coroutine> courutine, ICameraShake cameraShake)
        {
            _cameraShake = cameraShake;
            _corutine = courutine;
        }

        private IEnumerator SpawnRoutine()
        {
            for (int i = 0; i < _cyclesAmmount; i++)
            {
                _points.Shuffle();
                yield return ShowAttentions();
                yield return SpawnStones();
            }
        }

        public void StartFall() => _corutine.Invoke(SpawnRoutine());

        private IEnumerator ShowAttentions()
        {
            for (int i = 0; i < _points.Length / 2; i++)
            {
                _points[i].ShowAttention();
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
        }

        private IEnumerator SpawnStones()
        {
            _cameraShake.StartShake();
            for (int i = 0; i < _points.Length / 2; i++)
            {
                Spawn(i);
                yield return WaitRandomTime();
            }

            yield return new WaitForSeconds(1.5f);
        }

        private IEnumerator WaitRandomTime()
        {
            float _delay = Random.Range(0, 0.125f);
            yield return new WaitForSeconds(_delay);
        }

        private void Spawn(int index) => Object.Instantiate(_template, _points[index].Position, Quaternion.identity);
    }
}
