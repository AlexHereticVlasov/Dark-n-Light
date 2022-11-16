public sealed class Diamond : BaseCollectable
{
    protected override void Collect(Player player)
    {
        Destroy(gameObject);
    }
}

public interface IActor { }