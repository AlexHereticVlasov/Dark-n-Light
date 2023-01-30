using UnityEngine;

public class AchievementBar : MonoBehaviour
{
    [SerializeField] private AchievementCell _template;
    [SerializeField] private AchievementInfoWindow infoWindow;
    [SerializeField] private RectTransform _content;

    private void Start()
    {
        //ToDo: get Loaded data
        int amount = 50;

        for (int i = 0; i < amount; i++)
        {
            var cell = Instantiate(_template, _content);
            cell.Show += infoWindow.OnShow;
            cell.Hide += infoWindow.OnHide;
            //ToDo: Init cell if it geted
        }

    }
}
