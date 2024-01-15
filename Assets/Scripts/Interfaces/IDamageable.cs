using UnityEngine.Events;

public interface IDamageable
{
    //Health Health { get; }
    Elements Element { get; }

    event UnityAction<float, float> HealthChanged;

    void TakeDamage(float amount);
}

public interface IHeliable : IDamageable
{
    void Heal(float amount);
}
