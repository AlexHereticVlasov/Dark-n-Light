using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    [CreateAssetMenu(fileName = nameof(CompositeBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(CompositeBehaviour))]
    public class CompositeBehaviour : FlockBehaviour
    {
        [SerializeField] private FlockBehaviour[] _behaviours;
        [SerializeField] private float[] _weigths;

        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 direction = Vector2.zero;
            for (int i = 0; i < _behaviours.Length; i++)
            {
                Vector2 partial = _behaviours[i].CalculateMovement(agent, context, flock) * _weigths[i];

                if (partial != Vector2.zero)
                {
                    if (partial.sqrMagnitude > _weigths[i] * _weigths[i])
                    {
                        partial.Normalize();
                        partial *= _weigths[i];
                    }

                    direction += partial;
                }
            }

            return direction;
        }
    }
}
