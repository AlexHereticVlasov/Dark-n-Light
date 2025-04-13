using System.Collections;
using UnityEngine;

public class BaseZone : MonoBehaviour
{
    [SerializeField] private BaseZoneEffect _enterEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _enterEffect.Apply(player);
    }
}

namespace TrueVision
{
    public abstract class TrueVisionBaseZoneEffect : BaseZoneEffect
    {
        [SerializeField] protected BaseFakeObject[] FakeObjects;
    }

    public sealed class TrueVisionEnterZoneEffect : TrueVisionBaseZoneEffect
    {
        public override void Apply(Player player)
        {
            foreach (var fake in FakeObjects)
                fake.BecomeTransperent();
        }
    }

    public sealed class TrueVisionExitZoneEffect : TrueVisionBaseZoneEffect
    {
        public override void Apply(Player player)
        {
            foreach (var fake in FakeObjects)
                fake.BecomeNormal();
        }
    }

    public abstract class BaseFakeObject : MonoBehaviour
    {
        protected Coroutine Coroutine;

        public void BecomeNormal() => Coroutine = StartCoroutine(BecomeNormalRoutine());

        public void BecomeTransperent() => Coroutine = StartCoroutine(BecomeTransperentRoutine());

        public abstract IEnumerator BecomeNormalRoutine();

        public abstract IEnumerator BecomeTransperentRoutine();
    }

    public sealed class SpriteFakeObject : BaseFakeObject
    {
        [SerializeField] private SpriteRenderer _renderer;

        public override IEnumerator BecomeNormalRoutine()
        {
            float alpha = 0;

            while (alpha < 1)
            {
                alpha += Time.deltaTime;
                ChangeTransperency(alpha);
                yield return null;
            }
        }

        public override IEnumerator BecomeTransperentRoutine()
        {
            float alpha = 1;

            while (alpha > 0)
            {
                alpha -= Time.deltaTime;
                ChangeTransperency(alpha);
                yield return null;
            }
        }

        private void ChangeTransperency(float alpha)
        {
            var color = _renderer.material.color;
            var newColor = new Color(color.r, color.g, color.b, alpha);
            _renderer.material.color = newColor;
        }
    }
}

