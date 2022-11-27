using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    [CreateAssetMenu(fileName = nameof(AwoidenceBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(AwoidenceBehaviour))]
    public class AwoidenceBehaviour : FlockBehaviour
    {
        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0) return Vector2.zero;

            Vector2 direction = Vector2.zero;
            int numberToAwoid = 0;
            foreach (var transform in context)
            {
                if (Vector2.SqrMagnitude(transform.position - agent.transform.position) < flock.SqrAwoidenceRadius)
                {
                    numberToAwoid++;
                    direction += (Vector2)(agent.transform.position - transform.position);
                }
            }

            if (numberToAwoid > 0)
                direction /= numberToAwoid;

            return direction;
        }
    }
}
