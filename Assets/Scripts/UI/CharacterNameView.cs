using TMPro;
using UnityEngine;

public sealed class CharacterNameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Init(Player player)
    {
        _text.text = player.name;
    }
}
