using UnityEngine;

[System.Serializable]
public sealed class LevelData
{
    [field: SerializeField] public bool WasComplited { get; private set; }
    [field: SerializeField] public int Score { get; private set; }

    public void MarkAsComplited() => WasComplited = true;

    public void UpdateScore(int newScore) => Score = newScore;
}
