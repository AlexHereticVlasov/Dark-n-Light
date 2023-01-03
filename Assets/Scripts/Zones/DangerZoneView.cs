using UnityEngine;

public class DangerZoneView : MonoBehaviour, IRecoloreable
{
    [SerializeField] DangerZone _zone;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ColorBean _bean;

    public void Recolor()
    {
        _renderer.color = _bean[_zone.Element];
    }
}
