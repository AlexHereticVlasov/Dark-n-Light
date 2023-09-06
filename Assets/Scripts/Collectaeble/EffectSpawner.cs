using Pool;
using UnityEngine;

public sealed class EffectSpawner : MonoBehaviour
{
    [SerializeField] private ElementBean _effectBeans;

    private IEffectOrigin _effectOrigin;

    private ObjectPool<PoolableParticles>[] _objectPools;
    //TODO:Add ObjectPool

    private void Awake()
    {
        _effectOrigin = GetComponent<IEffectOrigin>();
        CheckIsEffectoriginContaines();

        //_objectPools = new ObjectPool<PoolableParticles>[_effectBeans.Length];

        //for (int i = 0; i < _effectBeans.Length; i++)
        //{
        //    _objectPools[i] = new ObjectPool<PoolableParticles>(_effectBeans[(Elements)i][]);
        //}
    }

    private void OnEnable() => _effectOrigin.Spawned += OnSpawned;

    private void OnDisable() => _effectOrigin.Spawned -= OnSpawned;

    private void OnSpawned(Elements elements, Vector2 position) => SpawnEffects(elements, position);

    private void SpawnEffects(Elements elements, Vector2 position)
    {
        foreach (var particle in _effectBeans[elements].Particles)
            SpawnEffect(particle, position);
    }

    private void SpawnEffect(ParticleSystem particle, Vector2 position)
    {
        var effect = Instantiate(particle, position, Quaternion.identity);
        float duration = effect.main.duration + Time.deltaTime;
        Destroy(effect.gameObject, duration);
    }

    private void CheckIsEffectoriginContaines()
    {
        if (_effectOrigin == null)
            throw new System.Exception($"{name} at {transform.position} doesn't containe Component that emplement {nameof(IEffectOrigin)} interface");
    }
}
