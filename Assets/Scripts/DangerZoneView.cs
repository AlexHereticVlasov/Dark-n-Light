using UnityEngine;

public class DangerZoneView : MonoBehaviour
{
    [SerializeField] DangerZone _zone;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ColorBean _bean;

    private void OnEnable()
    {
        _renderer.color = _bean[_zone.Element];
    }
}
