using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    [CreateAssetMenu(fileName = nameof(AlighmentBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(AlighmentBehaviour))]
    public class AlighmentBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0) return agent.transform.up;

            Vector2 direction = Vector2.zero;
            foreach (var transform in context)
                direction += (Vector2)transform.up;

            direction /= context.Count;

            return direction;
        }
    }
}
