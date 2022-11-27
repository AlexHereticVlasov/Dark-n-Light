using System.Collections.Generic;
using UnityEngine;


namespace Boid
{
    [CreateAssetMenu(fileName = nameof(StayInRadiusBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(StayInRadiusBehaviour))]
    public class StayInRadiusBehaviour : FlockBehaviour
    {
        [SerializeField] private Vector2 _center;
        [SerializeField] private float _radius;

        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 centerOffset = _center - (Vector2)agent.transform.position;
            float t = centerOffset.magnitude / _radius;
            if (t < 0.9f)
            {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }
    }
}
