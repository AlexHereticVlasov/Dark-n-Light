using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private const int Offset = 3;

    [SerializeField] private SceneLoader _loader;

    [field:SerializeField] public int Value { get; private set; }

    public void Load() => _loader.LoadScene(Value + Offset);
}
