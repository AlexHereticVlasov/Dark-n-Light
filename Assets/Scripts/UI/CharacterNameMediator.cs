using UnityEngine;
using Zenject;

public sealed class CharacterNameMediator : MonoBehaviour
{
    [Inject] Player[] _players;
    [SerializeField] private CharacterNameView[] _view;

    private void Start()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            _view[i].Init(_players[i]);
        }
    }
}
