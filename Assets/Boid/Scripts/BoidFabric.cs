using System.Collections.Generic;
using UnityEngine;

namespace Boid
{
    public class BoidFabric : MonoBehaviour
    {
        private const float AgentDensety = 0.08f;
        [SerializeField] private FlockAgent[] _templates;
        [SerializeField] private int _amount = 50;

        public List<FlockAgent> Spawn()
        {
            List<FlockAgent> agents = new List<FlockAgent>();

            for (int i = 0; i < _amount; i++)
            {
                int index = Random.Range(0, _templates.Length);
                Vector2 position = Random.insideUnitCircle * _amount * AgentDensety;
                Quaternion rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));

                var newAgent = Instantiate(_templates[index], position, rotation, transform);

                agents.Add(newAgent);
            }

            return agents;
        }
    }
}
