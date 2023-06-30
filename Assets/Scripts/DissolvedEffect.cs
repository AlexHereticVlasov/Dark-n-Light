﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public sealed class DissolvedEffect : MonoBehaviour
{
    private const string ValueName = "_Value";
    private const string ColorName = "_Color";
    private const string SeedName = "_Seed";

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _material.SetVector(SeedName, Random.insideUnitCircle);
    }

    public void Evaluate(float alpha) => _material.SetFloat(ValueName, alpha);

    public void Init(Element element) => _material.SetColor(ColorName, element.DissolveColor);
}
