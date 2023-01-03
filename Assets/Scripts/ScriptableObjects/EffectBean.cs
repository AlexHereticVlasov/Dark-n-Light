using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(EffectBean), menuName = nameof(ScriptableObject) + " / " + nameof(EffectBean))]
public class EffectBean : ScriptableObject
{
    [SerializeField] private ParticleSystem[] _particles;

    public IEnumerable<ParticleSystem> Particles => _particles;
}
