using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        int number = SceneManager.GetActiveScene().buildIndex - Constants.LevelOffset + 1;
        _text.text = $"Level {number}";
    }
}