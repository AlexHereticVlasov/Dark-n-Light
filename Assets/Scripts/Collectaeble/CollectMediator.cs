using System;
using System.Collections.Generic;
using Runes;
using Timer;
using UnityEngine;
using Zenject;

public class CollectMediator : MonoBehaviour
{
    [Inject] private readonly IInventory _inventory;
    [Inject] private readonly IScore _score;
    [Inject] private readonly IGlobalLighting _lighting;
    [Inject] private readonly IRuneStorage _runeStorage;
    [Inject] private readonly IGravity _gravity;

    private BaseCollectable[] _collectables;

    private Dictionary<Type, Action<BaseCollectable>> _keyValuePairs;

    private void Awake() => _collectables = GetComponentsInChildren<BaseCollectable>();

    private void OnEnable()
    {
        foreach (var collectable in _collectables)
            collectable.Collected += OnCollected;
    }

    private void Start()
    {
        int[] diamonds = CountDiamonds();

        _inventory.Init(diamonds);

        _keyValuePairs = new Dictionary<Type, Action<BaseCollectable>>
        {
            { typeof(Diamond), AddDiamond},
            { typeof(SunShard), FadeOut},
            { typeof(MoonShard), FadeIn},
            { typeof(Rune), AddRune},
            { typeof(AntigravityCollectable), ChangeGravity},
            { typeof(GeluPart), ActivatePortals}
        };
    }

    private void OnDisable()
    {
        foreach (var collectable in _collectables)
            collectable.Collected -= OnCollected;
    }

    private int[] CountDiamonds()
    {
        var diamonds = new int[Enum.GetValues(typeof(Elements)).Length];
        foreach (var collectable in _collectables)
            if (collectable is Diamond diamond)
                diamonds[(int)diamond.Element] = diamonds[(int)diamond.Element] + 1;

        return diamonds;
    }

    private void OnCollected(BaseCollectable collectable)
    {
        var key = collectable.GetType();
        _keyValuePairs[key].Invoke(collectable);
    }

    private void FadeOut(BaseCollectable collectable) => _lighting.FadeOut();

    private void FadeIn(BaseCollectable collectable) => _lighting.FadeIn();

    private void AddRune(BaseCollectable collectable) => _runeStorage.Add();

    private void AddDiamond(BaseCollectable diamond)
    {
        _score.Add(diamond);
        _inventory.Collected(diamond.Element);
    }

    private void ChangeGravity(BaseCollectable collectable) => _gravity.Reverse();

    private void ActivatePortals(BaseCollectable collectable)
    { 
    
    }
}
