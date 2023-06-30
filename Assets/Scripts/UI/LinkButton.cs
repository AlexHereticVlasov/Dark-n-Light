using UnityEngine;

public sealed class LinkButton : MonoBehaviour
{
    [SerializeField] private string _referens;

    public void OpenURL() => Application.OpenURL(_referens);
}
