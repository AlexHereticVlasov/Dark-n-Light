using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Element), menuName = nameof(ScriptableObject) + " / " + nameof(Element))]
public class Element : ScriptableObject
{
    [SerializeField] private ParticleSystem[] _particles;

    [field: SerializeField] public Color MainColor { get; private set; }
    [field: SerializeField] public Color AdditionalColor { get; private set; }
    [field: SerializeField] public ParticleSystem Body { get; private set; }

    public IEnumerable<ParticleSystem> Particles => _particles;
}