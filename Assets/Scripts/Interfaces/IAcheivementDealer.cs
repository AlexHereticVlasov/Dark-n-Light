using UnityEngine.Events;

public interface IAcheivementDealer
{
    public Achievement Achivement { get; }

    public event UnityAction<Achievement> Retrieved;
}
