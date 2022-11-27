using UnityEngine;

namespace Boid
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgent : MonoBehaviour
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }


        private void Start()
        {
            Collider = GetComponent<Collider2D>();
        }

        public void Move(Vector2 velocity) 
        {
            transform.up = velocity;
            transform.position += (Vector3)(velocity * Time.deltaTime);
        }
    }
}
