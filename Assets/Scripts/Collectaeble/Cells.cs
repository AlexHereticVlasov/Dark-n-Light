using UnityEngine;

public class Cells : MonoBehaviour
{
    [SerializeField] private CellViev[] _vievs;
    [SerializeField] private ElementBean _bean;

    public void Init(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length; i++)
        {
            if (diamonds[i] != 0)
            {
                _vievs[i].gameObject.SetActive(true);
                _vievs[i].Init(_bean[(Elements)i].MainColor);
                _vievs[i].SetValue(diamonds[i]);
            }
        }
    }

    public void ChangeAmount(int[] diamonds)
    {
        for (int i = 0; i < diamonds.Length - 1; i++)
            _vievs[i].SetValue(diamonds[i]);
    }
}
