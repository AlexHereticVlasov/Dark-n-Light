using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class Mine : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;

    public event UnityAction Activated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IActor _))
            StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        //ToDo: Play Activation Sound
        Activated?.Invoke();
        yield return new WaitForSeconds(.25f);

        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
