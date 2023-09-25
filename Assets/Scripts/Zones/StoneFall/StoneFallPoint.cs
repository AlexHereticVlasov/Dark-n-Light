using UnityEngine.Events;
namespace StoneFall
{
    public sealed class StoneFallPoint : BasePoint
    {
        public event UnityAction Attention;

        public void ShowAttention() => Attention?.Invoke();
    }
}