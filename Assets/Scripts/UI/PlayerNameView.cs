using TMPro;
using UnityEngine;

public sealed class PlayerNameView : MonoBehaviour
{
    [SerializeField] private PlayerUIPresenter _presenter;
    [SerializeField] private ElementBean _bean;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _presenter.PlayerDeterminated += OnPlayerDeterminated;

    private void OnDisable() => _presenter.PlayerDeterminated -= OnPlayerDeterminated;

    private void OnPlayerDeterminated(Elements element) => _text.text = _bean.GetName(element);
}
