using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    [CreateAssetMenu(fileName = nameof(CohesionBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(CohesionBehaviour))]
    public class CohesionBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0) return Vector2.zero;

            Vector2 direction = Vector2.zero;
            foreach (var transform in context)
                direction += (Vector2)transform.position;

            direction /= context.Count;
            direction -= (Vector2)agent.transform.position;

            return direction;
        }
    }
}
