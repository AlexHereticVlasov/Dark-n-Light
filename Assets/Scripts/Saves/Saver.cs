using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Saver
{
    public static void SaveData<T>(T data, string fileName) where T : class
    {
        string path = GetPath(fileName);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    private static T LoadData<T>(string fileName) where T : class
    {
        string path = GetPath(fileName);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            T resoult = (T)formatter.Deserialize(fileStream);
            fileStream.Close();
            return resoult;
        }

        return null;
    }

    public static bool TryLoadData<T>(string fileName, out T data) where T : class
    {
        string path = GetPath(fileName);
        data = LoadData<T>(path);

        return data == null;
    }

    public static void DeleteFile(string fileName) => File.Delete(GetPath(fileName));

    private static string GetPath(string fileName) => Application.persistentDataPath + "/" + fileName + ".sav";
}
