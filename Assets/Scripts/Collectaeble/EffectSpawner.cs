using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private ElementBean _effectBeans;

    private IEffectOrigin _effectOrigin;

    private void Awake()
    {
        _effectOrigin = GetComponent<IEffectOrigin>();
        CheckIsEffectoriginContaines();
    }

    private void OnEnable() => _effectOrigin.Spawned += OnSpawned;

    private void OnDisable() => _effectOrigin.Spawned -= OnSpawned;

    private void OnSpawned(Elements elements) => SpawnEffects(elements);

    private void SpawnEffects(Elements elements)
    {
        foreach (var particle in _effectBeans[elements].Particles)
            SpawnEffect(particle);
    }

    private void SpawnEffect(ParticleSystem particle)
    {
        var effect = Instantiate(particle, transform.position, Quaternion.identity);
        float duration = effect.main.duration;
        Destroy(effect, duration);
    }

    private void CheckIsEffectoriginContaines()
    {
        if (_effectOrigin == null)
            throw new System.Exception($"{name} at {transform.position} doesn't containe Component that emplement {nameof(IEffectOrigin)} interface");
    }
}
