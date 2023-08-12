using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public sealed class LightRay : MonoBehaviour
{
    private const string ReflectionTag = "Mirror";

    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private float _angularSpeed;

    private void Start() => _renderer.SetPosition(0, transform.position);

    private void Update()
    {
        transform.Rotate(Vector3.forward, _angularSpeed * Time.deltaTime, Space.World);

        int pointsAmount = 1;
        var ray = new Ray2D(transform.position, -transform.right);
        BuildRay(ray, gameObject, ref pointsAmount);
        _renderer.positionCount = pointsAmount + 1;
    }

    private void BuildRay(Ray2D ray2D, GameObject @this, ref int index)
    {
        var hits = Physics2D.RaycastAll(ray2D.origin, ray2D.direction, 100);

        foreach (var hit in hits)
        {
            if (hit.transform.gameObject == @this)
                continue;

            _renderer.SetPosition(index, hit.point);
            if (hit.transform.CompareTag(ReflectionTag))
            {
                Vector2 reflection = Vector2.Reflect(ray2D.direction, hit.normal);
                index++;
                _renderer.positionCount = index + 1;
                var ray = new Ray2D(hit.point, reflection);
                BuildRay(ray, hit.transform.gameObject, ref index);
            }
            //ToDo: Portals
            else
            {
                //TODO: Place Particles
                //TODO: TryActivate
            }
            return;
        }
    }
}
