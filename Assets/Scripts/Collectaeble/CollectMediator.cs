using System;
using System.Collections.Generic;
using Timer;
using UnityEngine;
using Zenject;

public class CollectMediator : MonoBehaviour
{
    [Inject] private IInventory _inventory;
    [Inject] private IScore _score;
    [Inject] private IGlobalLighting _lighting;

    private BaseCollectable[] _collectables;

    //private Dictionary<Type, Action> keyValuePairs;

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
        var type = collectable.GetType();

        if (collectable is Diamond diamond)
        {
            _score.Add(diamond);
            _inventory.Collected(diamond.Element);
            return;
        }

        //ToDo:Collectable is SunShard
        if (collectable is SunShard sunShard)
        {
            _lighting.FadeOut();
            return;
        }

        if (collectable is MoonShard moonShard)
        {
            _lighting.FadeIn();
            return;
        }

        //ToDo:Collectable is Rune, add rune to RuneStorage
        if (collectable is Rune rune)
        {
            //
            return;
        }
    }
}

