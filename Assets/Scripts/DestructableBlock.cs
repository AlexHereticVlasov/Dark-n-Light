using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DestructableBlock : MonoBehaviour
{
    [SerializeField] private Elements _element;

    public event UnityAction<float> Melted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            if (player.Element == _element)
                StartCoroutine(Melt());
    }

    private IEnumerator Melt()
    {
        float factor = 1;

        while (factor > 0)
        {
            factor -= Time.deltaTime;
            Melted?.Invoke(factor);
            yield return null;
        }

        Destroy(gameObject);
    }
}
