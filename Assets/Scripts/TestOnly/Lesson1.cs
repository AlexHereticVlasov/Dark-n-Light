using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    private void Start()
    {
        int peoples = 14;
        int length = 10;

        int totalTime = peoples * length;

        int hours = totalTime / 60;
        int minutes = totalTime % 60;

        Debug.Log($"Hours: {hours}, Minutes {minutes}");

        
    }
}
