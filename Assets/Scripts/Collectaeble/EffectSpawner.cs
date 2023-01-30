using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private ElementBean _effectBeans;

    private IEffectOrigin _effectOrigin;

    private void Awake()
    {
        _effectOrigin = GetComponent<IEffectOrigin>();

        if (_effectOrigin == null)
            throw new System.Exception($"{name} at {transform.position} doesn't containe Component that emplement {nameof(IEffectOrigin)} interface");
    }

    private void OnEnable() => _effectOrigin.Spawned += OnSpawned;

    private void OnDisable() => _effectOrigin.Spawned -= OnSpawned;

    private void OnSpawned(Elements elements) => SpawnEffect(elements);

    private void SpawnEffect(Elements elements)
    {
        foreach (var particle in _effectBeans[elements].Particles)
        {
            var effect = Instantiate(particle, transform.position, Quaternion.identity);
            float duration = effect.main.duration;
            Destroy(effect, duration);
        }
    }
}
