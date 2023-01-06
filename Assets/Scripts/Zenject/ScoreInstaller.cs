using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] private Score _score;

    public override void InstallBindings()
    {
        Container.Bind<Score>().FromInstance(_score).AsSingle().NonLazy();
        Container.QueueForInject(_score);
    }
}
