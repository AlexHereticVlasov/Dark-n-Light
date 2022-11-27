﻿using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TourchView : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Tourch _tourch;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnEnable()
    {
        _tourch.Activated += OnActivated;
        _tourch.Deactivated += OnDeactivated;
    }

    private void Start()
    {
        if (_tourch.IsActive)
            OnActivated();
    }

    private void OnDisable()
    {
        _tourch.Activated -= OnActivated;
        _tourch.Deactivated -= OnDeactivated;
    }

    private void OnDeactivated()
    {
        _renderer.color = Color.blue;
        _light.intensity = 0;
    }

    private void OnActivated()
    {
        _renderer.color = Color.yellow;
        _light.intensity = 1;
    }
}
