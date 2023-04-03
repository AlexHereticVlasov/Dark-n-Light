using UnityEngine;

public class Achievements : MonoBehaviour
{
    [SerializeField] private AchievementMessage _template;
    [SerializeField] private RectTransform _spawnPoint;
    [SerializeField] private GameObject[] _dealers;

    private void OnEnable()
    {
        foreach (var dealer in _dealers)
            if (dealer.TryGetComponent(out IAcheivementDealer achievementDealer))
                achievementDealer.Retrieved += Spawn;
    }

    private void OnDisable()
    {
        foreach (var dealer in _dealers)
            if (dealer.TryGetComponent(out IAcheivementDealer achievementDealer))
                achievementDealer.Retrieved -= Spawn;
    }

    private void Spawn(Achievement achivement)
    {
        var message = Instantiate(_template, _spawnPoint.position, Quaternion.identity, _spawnPoint);
        message.Init(achivement);
    }
}
