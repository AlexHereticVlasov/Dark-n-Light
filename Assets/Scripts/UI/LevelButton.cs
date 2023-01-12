using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;

    [field:SerializeField] public int Value { get; private set; }

    public void Load() => _loader.LoadScene(Value + Constants.LevelOffset);
}
