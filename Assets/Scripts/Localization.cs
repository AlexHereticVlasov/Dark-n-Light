using UnityEngine;

public class Localization : MonoBehaviour
{ 

}

[System.Serializable]
public sealed class SaveData
{
    [SerializeField] private LevelData[] _levels;

    public SaveData()
    {
        _levels = new LevelData[200];

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i] = new LevelData();
        }
    }
}

[System.Serializable]
public sealed class LevelData
{
    [field: SerializeField] public bool WasComplited { get; private set; }
    [field:SerializeField] public int Score { get; private set; }
}
