using UnityEngine.Events;

public interface IAchivementDealer
{
    public Achievement Achivement { get; }

    public event UnityAction<Achievement> Retrieved;
}
