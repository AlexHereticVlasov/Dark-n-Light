using UnityEngine;
using UnityEngine.Events;

public class Localization : MonoBehaviour
{
    [SerializeField] private BaseSave _save;

    public event UnityAction<Languages> LanguageChainged;

    private void Start()
    {
        Languages language = _save.Data.Language;
        LanguageChainged?.Invoke(language);
    }
}
