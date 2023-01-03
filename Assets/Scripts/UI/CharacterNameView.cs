using TMPro;
using UnityEngine;

public class CharacterNameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private UserInput _input;

    private void OnEnable() => _input.CharacterSwithed += OnCharacterSwithed;

    private void OnDisable() => _input.CharacterSwithed -= OnCharacterSwithed;
    //TODO: Get data from SO with localization
    private void OnCharacterSwithed(Player player) => _text.text = player.Element.ToString();
}
