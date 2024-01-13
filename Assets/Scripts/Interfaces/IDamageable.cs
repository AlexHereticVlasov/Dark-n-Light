using UnityEngine.Events;

public interface IDamageable
{
    float MaxHealth { get; }
    float Health { get; }
    Elements Element { get; }

    event UnityAction<float, float> HealthChanged;

    void TakeDamage();
}

public interface IHeliable : IDamageable
{
    void Heal(float amount);
}
