using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseDestructableBlock : MonoBehaviour 
{
    public event UnityAction<float> TransperancyChanged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            if (ShouldMelt(player))
                StartCoroutine(Melt());
    }

    protected abstract bool ShouldMelt(Player player);
    
    protected abstract void Remove();

    private IEnumerator Melt()
    {
       

        float factor = 1;

        while (factor > 0)
        {
            factor -= Time.deltaTime;
            yield return ChangeTransperancy(factor);   
        }
        //ToDo: need better name for this method
        Remove();
    }

    protected IEnumerator ChangeTransperancy(float factor)
    {
        TransperancyChanged?.Invoke(factor);
        yield return null;
    }

}
