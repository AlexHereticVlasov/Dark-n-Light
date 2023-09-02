using UnityEngine;

public sealed class RuneAltarView : MonoBehaviour
{
    [SerializeField] private RuneAltarZoneEffect _altarZoneEffect;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable() => _altarZoneEffect.Activated += OnActivated;

    private void OnDisable() => _altarZoneEffect.Activated -= OnActivated;

    private void OnActivated() => _renderer.enabled = true;
}

