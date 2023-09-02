using CameraShaker;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Pool;

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

        private ObjectPool<FallingStone> _pool;

        public event UnityAction FallComplited;

        public void Init(System.Func<IEnumerator, Coroutine> courutine, ICameraShake cameraShake)
        {
            _pool = new ObjectPool<FallingStone>(_template);
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

            FallComplited?.Invoke();
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

        private void Spawn(int index)
        {
            var instance = _pool.Get();
            instance.transform.position = _points[index].Position;
            instance.Reuse();
        }
    }
}
