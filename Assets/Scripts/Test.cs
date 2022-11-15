using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector2 _direction;
    private float _speed = 3;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * _speed;
        float y = _body.velocity.y;
        _direction = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        _body.velocity = _direction;
    }
}
