using UnityEngine;
using TMPro;

public class Localizable : MonoBehaviour
{
    [SerializeField] private Localization _localization; //ToDo: Inject it
    [SerializeField] private LocalizationBean _bean;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _localization.LanguageChainged += OnLanguageChainged;

    private void OnDisable() => _localization.LanguageChainged -= OnLanguageChainged;

    private void OnLanguageChainged(Languages language) => _text.text = _bean[language];
}
