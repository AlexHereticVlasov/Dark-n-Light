using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=DbQjieYgAKA&list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d&index=9

namespace Boid
{
    [RequireComponent(typeof (BoidFabric))]
    public class Flock : MonoBehaviour
    {
        private BoidFabric _fabric;

        [SerializeField] private FlockBehaviour _behaviour;
        [SerializeField] private float _driveFactor = 10;
        [SerializeField] private float _maxSpeed = 5;
        [SerializeField] private float _neighbourRadius = 1.5f;
        [SerializeField] private float _awoidenceRadiusMultiplier = 0.5f;

        private float _sqrMaxSpeed;
        private float _sqrNeighbourRadius;

        private List<FlockAgent> _agents = new List<FlockAgent>();
        public float SqrAwoidenceRadius { get; private set; }

        private void Init()
        {
            _fabric = GetComponent<BoidFabric>();
            _sqrMaxSpeed = _maxSpeed * _maxSpeed;
            _sqrNeighbourRadius = _neighbourRadius * _neighbourRadius;
            SqrAwoidenceRadius = _sqrNeighbourRadius * _awoidenceRadiusMultiplier * _awoidenceRadiusMultiplier;
        }

        private void Start()
        {
            Init();

            _agents = _fabric.Spawn();
        }

        private void Update()
        {
            foreach (var agent in _agents)
            {
                List<Transform> context = GetNearbyObjects(agent);
                Vector2 direction = _behaviour.CalculateMovement(agent, context, this);
                direction *= _driveFactor;

                if (direction.sqrMagnitude > _sqrMaxSpeed)
                    direction = direction.normalized * _maxSpeed;

                agent.Move(direction);
            }
        }

        private List<Transform> GetNearbyObjects(FlockAgent agent)
        {
            var context = new List<Transform>();
            var colliders = Physics2D.OverlapCircleAll(agent.transform.position, _neighbourRadius);
            
            foreach (var collider in colliders)
                if (collider != agent.Collider)
                    context.Add(collider.transform);

            return context;
        }
    }
}


