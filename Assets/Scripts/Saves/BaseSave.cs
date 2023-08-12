using UnityEngine;

public class BaseSave : MonoBehaviour
{
    private const string SaveName = "Save";
    [field:SerializeField] public SaveData Data { get; private set; }

    private void Awake()
    {
        if (Saver.TryLoadData(SaveName, out SaveData data))
        {
            Debug.Log("Loaded");
            Data = data;
            return;
        }

        Debug.Log("Created");
        Data = new SaveData();
        Saver.SaveData(Data, SaveName);
    }

    private void OnVictory()
    {
        //ToDo: Change Data to save

        Saver.SaveData(Data, SaveName);
    }

    public int GetTotalScore()
    {
        return 0;
    }
}
