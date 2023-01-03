﻿using System;
using UnityEngine;

public class CollectMediator : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    private BaseCollectable[] _collectables;

    private void Awake() => _collectables = GetComponentsInChildren<BaseCollectable>();

    private void OnEnable()
    {
        foreach (var collectable in _collectables)
            collectable.Collected += OnCollected;
    }

    private void Start()
    {
        var diamonds = new int[Enum.GetValues(typeof(Elements)).Length];
        foreach (var collectable in _collectables)
            if (collectable is Diamond diamond)
                diamonds[(int)diamond.Element] = diamonds[(int)diamond.Element] + 1;

        _inventory.Init(diamonds);
    }

    private void OnDisable()
    {
        foreach (var collectable in _collectables)
            collectable.Collected -= OnCollected;
    }

    private void OnCollected(BaseCollectable collectable)
    {
        //??
        if (collectable is Diamond diamond)
        {
            _inventory.Collected(diamond.Element);
        }
    }
}

