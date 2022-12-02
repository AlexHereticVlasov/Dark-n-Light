using UnityEngine;
//Diamonds
//Shots

public abstract class BaseCollectable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectTemplate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (CanCollect(player))
            {
                Collect(player);
                SpawnEffect();
            }
        }
    }

    protected abstract void Collect(Player player);

    protected abstract bool CanCollect(Player player);

    private void SpawnEffect()
    {
        var effect = Instantiate(_effectTemplate, transform.position, Quaternion.identity);
        float duration = effect.main.duration;
        Destroy(effect, duration);
    }
}
