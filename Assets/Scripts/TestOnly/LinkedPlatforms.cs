using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedPlatforms : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _first;
    [SerializeField] private Rigidbody2D _second;

    private void Update()
    {
        
        //mass
        //if (_first.velocity.magnitude > _second.velocity.magnitude)
        //{
        //    _second.velocity = -_first.velocity;
        //}
        //else
        //{
        //    _first.velocity = -_second.velocity;
        //}
    }

    private void FixedUpdate()
    {
        if (true)
        {
            _second.position = new Vector2(_second.position.x, -_first.position.y);

        }
        else
        {
            _first.position = new Vector2(_first.position.x, -_second.position.y);
        }
    }
}

public class PlatformMass : MonoBehaviour
{ 
    public float Value { get; private set; }
}
