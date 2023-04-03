using UnityEngine;

public class DangerZoneView : MonoBehaviour, IRecoloreable
{
    [SerializeField] DangerZone _zone;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ElementBean _bean;
    [SerializeField] private ParticleSystem _particles;

    [Header("Settings")]
    [SerializeField] private Vector2 _size = Vector2.one;

    //ToDo: Create Mode with out particles
    public void Recolor()
    {
        _renderer.material = _bean[_zone.Element].PoolMaterial;

        if (_size.x <= 0 || _size.y <= 0)
            throw new System.Exception("Size must be more zero");

        var main = _particles.main;
        main.startColor = _bean[_zone.Element].AdditionalColor;

        var emission = _particles.emission;
        emission.rateOverTime = Mathf.RoundToInt(100 * _size.x * _size.y);

        var shape = _particles.shape;
        shape.scale = new Vector2(_size.x - 0.5f, _size.y);

        _renderer.transform.localScale = _size;

        var collider = GetComponent<BoxCollider2D>();
        collider.size = _size;
    }
}
