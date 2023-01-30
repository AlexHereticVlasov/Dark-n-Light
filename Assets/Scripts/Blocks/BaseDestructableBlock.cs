using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseDestructableBlock : MonoBehaviour, IEffectOrigin 
{
    //public event UnityAction StartMelted;
    public event UnityAction Restored;
    public event UnityAction<float> TransperancyChanged;
    public event UnityAction<Elements> Spawned;

    [field: SerializeField] public Elements Element { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            if (ShouldMelt(player))
                StartCoroutine(Melt());
    }

    protected abstract bool ShouldMelt(Player player);
    
    protected abstract void Finish();

    private IEnumerator Melt()
    {
        Spawned?.Invoke(Element);
        float factor = 1;

        while (factor > 0)
        {
            factor -= Time.deltaTime;
            yield return ChangeTransperancy(factor);   
        }

        Finish();
    }

    protected IEnumerator ChangeTransperancy(float factor)
    {
        TransperancyChanged?.Invoke(factor);
        yield return null;
    }

    protected virtual void Restore() => Restored?.Invoke();
}
