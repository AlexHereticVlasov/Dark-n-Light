using UnityEngine;

public sealed class LevelZoneView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void Recolor(Color[] colors)
    {
        var main = _particle.main;
        main.startColor = colors[0];

    }
}
