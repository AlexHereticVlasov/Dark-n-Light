﻿using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DiamondViev : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Light2D _light;

    //Hack:Temp Solution
    [SerializeField] private ColorBean _colors;

    private void OnEnable()
    {
        _renderer.color = _colors[_diamond.Element];
        _light.color = Color.Lerp(Color.white, _colors[_diamond.Element], 0.5f);
    }
}
