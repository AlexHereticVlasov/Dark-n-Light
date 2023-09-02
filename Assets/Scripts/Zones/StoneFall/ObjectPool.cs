using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public sealed class ObjectPool<T> where T : MonoBehaviour, IPooleable
    {
        private T _template;
        private Stack<T> _stack;

        public ObjectPool(T template)
        {
            _stack = new Stack<T>();
            _template = template;
        }

        public T Get()
        {
            var instance = _stack.Count > 0 ? _stack.Pop() : Object.Instantiate(_template);
            instance.UseageComplited += OnUseageComplited;
            return instance;
        }

        private void OnUseageComplited(IPooleable pooleable) => Add((T)pooleable);

        public void Add(T pooleable)
        {
            pooleable.UseageComplited -= OnUseageComplited;
            pooleable.gameObject.SetActive(false);
            _stack.Push(pooleable);
        }
    }
}