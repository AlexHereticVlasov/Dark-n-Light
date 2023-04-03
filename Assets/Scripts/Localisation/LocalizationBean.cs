using UnityEngine;

[CreateAssetMenu(fileName = nameof(LocalizationBean), menuName = nameof(ScriptableObject) + " / " + nameof(LocalizationBean))]
public class LocalizationBean : ScriptableObject
{
    [SerializeField] private string[] _strings;

    public string this[Languages language] => _strings[(int) language];
}
