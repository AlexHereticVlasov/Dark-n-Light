using UnityEngine;

public interface ICells
{
    public void Init(int[] diamonds);
    public void ChangeAmount(int[] diamonds);
}

public sealed class Cells : MonoBehaviour, ICells
{
    [SerializeField] private CellViev[] _vievs;
    [SerializeField] private ElementBean _bean;

    public void Init(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length; i++)
        {
            if (diamonds[i] == 0) continue;

            _vievs[i].gameObject.SetActive(true); //TODO: Remove all this logic inside single cellView
            _vievs[i].Init(_bean[(Elements)i].MainColor);
            _vievs[i].SetValue(diamonds[i]);
        }
    }

    public void ChangeAmount(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length - 1; i++)
            _vievs[i].SetValue(diamonds[i]);
    }
}
