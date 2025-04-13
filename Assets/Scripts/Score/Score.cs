using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Timer
{
    public sealed class Score : MonoBehaviour, IScore, IHardModeCounter, IInitable
    {
        private readonly int _startValue = 60;
        private readonly WaitForSeconds _delay = new(1);

        [Inject] private readonly IVictory _victory;

        private int _value;
        private bool _isGameOver;
        private bool _timeIsRunningOut;

        public event UnityAction<int> ValueChanged;
        public event UnityAction TimeIsOwer;
        public event UnityAction TimeRestored;

        private void Start()
        {
            //Hack: TempSolution;
            _value = _startValue;
            ValueChanged?.Invoke(_value);
            //
            StartCoroutine(CountTime());
        }

        private void OnEnable() => _victory.Win += OnWin;

        private void OnDisable() => _victory.Win -= OnWin;

        private void OnWin() => _isGameOver = true;

        private IEnumerator CountTime()
        {
            while (_isGameOver == false)
            {
                yield return _delay;

                if (_value > 0)
                    Decrease();

                TryStartHardMode();
            }
        }

        private void Decrease()
        {
            _value--;
            ValueChanged?.Invoke(_value);
        }

        public void Add(BaseCollectable collectable)
        {
            _value += collectable.Cost;
            ValueChanged?.Invoke(_value);

            if (_timeIsRunningOut == false) return;

            _timeIsRunningOut = false;
            TimeRestored?.Invoke();
        }

        private void TryStartHardMode()
        {
            if (ShouldNotStartHardMode()) return;

            TimeIsOwer?.Invoke();
            _timeIsRunningOut = true;
        }

        private bool ShouldNotStartHardMode() => _timeIsRunningOut || _value > 0;

        public void Init(Level level)
        {
            _value = level.StartTime;
            ValueChanged?.Invoke(_value);
        }
    }
}

public interface IInitable
{
    void Init(Level level);
}