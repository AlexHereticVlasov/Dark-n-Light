using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed = 15f;
    public float hitOffset = 0f;
    public bool UseFirePointRotation;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public GameObject hit;
    public GameObject flash;
    private Rigidbody2D _rigidbody;
    public GameObject[] Detached;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (flash != null)
        {
            var flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
            flashInstance.transform.forward = gameObject.transform.forward;
            var flashPs = flashInstance.GetComponent<ParticleSystem>();
            if (flashPs == null)
            {
                var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(flashInstance, flashPsParts.main.duration);
            }
            else
            {
                Destroy(flashInstance, flashPs.main.duration);
            }
        }

        Destroy(gameObject, 5);
    }

    private void FixedUpdate() => Move();

    private void Move()
    {
        if (speed != 0)
            _rigidbody.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        speed = 0;

        var contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point + contact.normal * hitOffset;

        if (hit != null)
        {
            var hitInstance = Instantiate(hit, position, rotation);
            if (UseFirePointRotation)
                hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0);
            else if (rotationOffset != Vector3.zero)
                hitInstance.transform.rotation = Quaternion.Euler(rotationOffset);
            else
                hitInstance.transform.LookAt(contact.point + contact.normal);


            var hitPs = hitInstance.GetComponent<ParticleSystem>();
            if (hitPs == null)
            {
                var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitInstance, hitPsParts.main.duration);
            }
            else
            {
                Destroy(hitInstance, hitPs.main.duration);
            }
        }
        foreach (var detachedPrefab in Detached)
        {
            if (detachedPrefab != null)
                detachedPrefab.transform.parent = null;
        }

        Destroy(gameObject);
    }
}