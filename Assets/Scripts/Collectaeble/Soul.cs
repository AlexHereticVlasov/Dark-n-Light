using System.Collections;
using UnityEngine;

public class Soul : BaseCollectable
{
    [SerializeField] private BaseActivailiable _destination;

    protected override bool CanCollect(Player player) => true;

    protected override void Collect(Player player) => StartCoroutine(FlyRoutine());

    private IEnumerator FlyRoutine()
    {
        //Fly to destination Point
        while (IsTargetReached() == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination.transform.position, 5 * Time.deltaTime);
            yield return null;
        }

        transform.SetParent(_destination.transform);
        _destination.Activate();
    }

    private bool IsTargetReached()
    {
        return Vector2.Distance(transform.position, _destination.transform.position) > 0.1f;
    }

    static int[] ReadInput(string userInput)
    {
        string[] numbers = userInput.Split(',', ' ');
        int[] result = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (int.TryParse(numbers[i], out int number))
            {
                result[i] = number;
                continue;
            }

            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine($"{numbers[i]} - Нихуя не число");
            break;
        }

        return result;
    }
}
