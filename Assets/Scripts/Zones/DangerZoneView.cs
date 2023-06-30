using UnityEngine;

public sealed class DangerZoneView : MonoBehaviour, IRecoloreable
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

        SetParticlesStartColor();
        SetParticlesEmissionRateOverTime();
        SetParticlesShapeScale();
        _renderer.transform.localScale = _size;
        SetColliderSize();
    }

    private void SetParticlesStartColor()
    {
        var main = _particles.main;
        main.startColor = _bean[_zone.Element].AdditionalColor;
    }

    private void SetParticlesEmissionRateOverTime()
    {
        var emission = _particles.emission;
        emission.rateOverTime = Mathf.RoundToInt(100 * _size.x * _size.y);
    }

    private void SetParticlesShapeScale()
    {
        var shape = _particles.shape;
        shape.scale = new Vector2(_size.x - 0.5f, _size.y);
    }

    private void SetColliderSize()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.size = _size;
    }
}
