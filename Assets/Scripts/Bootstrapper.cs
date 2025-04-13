using UnityEngine;
using Zenject;

public sealed class Bootstrapper : MonoBehaviour
{
    [SerializeField] private AllLevels _allLevels;

    [Inject] private readonly IInitable _ambientPlayer;
    [Inject] private readonly IInitable _score;

    private void Awake()
    {
        var level = _allLevels.GetCurrent();

        _ambientPlayer.Init(level);
        _score.Init(level);
    }
}
