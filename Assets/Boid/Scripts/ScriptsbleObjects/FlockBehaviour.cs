using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    public abstract class FlockBehaviour : ScriptableObject
    {
        public abstract Vector2 CalculateMovement(FlockAgent agent, List<Transform> context, Flock flock);
    }
}
