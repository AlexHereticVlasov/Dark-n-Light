using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Element), menuName = nameof(ScriptableObject) + " / " + nameof(Element))]
public class Element : ScriptableObject
{
    [SerializeField] private ParticleSystem[] _particles;

    [field: SerializeField] public Color MainColor { get; private set; }
    [field: SerializeField] public Color AdditionalColor { get; private set; }
    [field: SerializeField] public Color32 DissolveColor { get; private set; }
    [field: SerializeField] public ParticleSystem Body { get; private set; }
    [field: SerializeField] public Material PoolMaterial { get; private set; }
    [field: SerializeField] public Sprite DestructableStone { get; private set; }

    public IEnumerable<ParticleSystem> Particles => _particles;
}