﻿using Zenject;

public sealed class LevelFadePanel : BaseFadePanel
{
    [Inject] private Lose _lose;
    [Inject] private Victory _victory;

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