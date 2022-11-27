using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    [CreateAssetMenu(fileName = nameof(SteeredCohesionBehaviour), menuName = nameof(ScriptableObject) + " / " + nameof(Boid) + " / " + nameof(SteeredCohesionBehaviour))]
    public class SteeredCohesionBehaviour : FlockBehaviour
    {
        [SerializeField] private float _smoothTime = 0.5f;
        private Vector2 _curentVelocity;

        public override Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0) return Vector2.zero;

            Vector2 direction = Vector2.zero;
            foreach (var transform in context)
                direction += (Vector2)transform.position;

            direction /= context.Count;
            direction -= (Vector2)agent.transform.position;
            direction = Vector2.SmoothDamp(agent.transform.up, direction, ref _curentVelocity, _smoothTime);
            return direction;
        }
    }
}
