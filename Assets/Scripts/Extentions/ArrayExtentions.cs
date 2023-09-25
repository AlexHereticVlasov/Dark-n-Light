using UnityEngine;

public static class ArrayExtentions
{
    public static void Shuffle<T>(this T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var temp = array[i];
            int index = Random.Range(0, array.Length);
            array[i] = array[index];
            array[index] = temp;
        }
    }
}