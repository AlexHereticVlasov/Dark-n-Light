using Zenject;

public sealed class LevelFadePanel : BaseFadePanel
{
    [Inject] private readonly ILose _lose;
    [Inject] private readonly IVictory _victory;

    private void OnEnable()
    {
        _victory.Win += OnWin;
        _lose.Defeate += OnDefeate;
    }

    private void OnDisable()
    {
        _victory.Win -= OnWin;
        _lose.Defeate -= OnDefeate;
    }

    private void OnDefeate() => FadeIn();

    private void OnWin() => FadeIn();
}