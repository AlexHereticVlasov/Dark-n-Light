﻿using UnityEngine;

public class PortalAdditionalEffect : MonoBehaviour
{
    [SerializeField] private LevelEndEnterEffect _enterEffect;
    [SerializeField] private ParticleSystem _particles;

    private void OnEnable() => _enterEffect.PlayerInside += OnPlayerInside;

    private void OnDisable() => _enterEffect.PlayerInside -= OnPlayerInside;

    private void OnPlayerInside(Player player)
    {
        //if (_enterEffect.Element == player.Element)
        //{
        _particles.Play();
        //}
    }
}

public class PortalAditionalEffectView : MonoBehaviour
{
    //[SerializeField] private 
}
