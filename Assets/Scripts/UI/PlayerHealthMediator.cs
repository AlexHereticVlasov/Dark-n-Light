using UnityEngine;
using Zenject;

public sealed class PlayerHealthMediator : MonoBehaviour
{
    [Inject] private Player[] _players;
    [SerializeField] private PlayerUIPresenter[] _presenters;

    private void Start()
    {
        for (int i = 0; i < _players.Length; i++)
            _presenters[i].Init(_players[i]);
    }
}
