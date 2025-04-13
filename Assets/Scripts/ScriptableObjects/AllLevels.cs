using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = nameof(AllLevels), menuName = nameof(ScriptableObject) + " / " + nameof(AllLevels))]
public sealed class AllLevels : ScriptableObject
{
    [SerializeField] private Level[] _levels;

    public Level GetCurrent()
    {
        int index = SceneManager.GetActiveScene().buildIndex - Constants.LevelOffset;
        return _levels[index];
    }
}
