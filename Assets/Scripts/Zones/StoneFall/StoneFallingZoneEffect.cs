using UnityEngine.Events;

namespace StoneFall
{
    public sealed class StoneFallingZoneEffect : BaseZoneEffect
    {
        public event UnityAction FallStarted;

        public override void Apply(Player player) => FallStarted?.Invoke();
    }
}