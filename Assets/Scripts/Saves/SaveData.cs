using UnityEngine;

[System.Serializable]
public sealed class SaveData
{
    [SerializeField] private LevelData[] _levels;

    public Languages Language { get; private set; }

    public SaveData()
    {
        _levels = new LevelData[200];

        for (int i = 0; i < _levels.Length; i++)
            _levels[i] = new LevelData();
    }

    public void ChaingeLanguage(Languages language) => Language = language;

    public void MarkAsComplited(int index)
    {
        _levels[index].MarkAsComplited();
    }

    public void UpdateScore(int level, int newScore)
    {
        if (_levels[level].Score < newScore)
            _levels[level].UpdateScore(newScore);
    }
}
