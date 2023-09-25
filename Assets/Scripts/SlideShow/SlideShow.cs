using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using SceneLoad;

public interface ISlideShow
{
    event UnityAction<Slide> SlideChanged;
    void Skip();
}

public sealed class SlideShow : MonoBehaviour, ISlideShow
{
    [SerializeField] private int _nextScene;
    [SerializeField] private Slide[] slides;

    [Inject] private ISceneLoader _loader;

    private bool _canSkip = true;
    private Coroutine _playRoutine;

    public event UnityAction<Slide> SlideChanged;

    private void Start() => _playRoutine = StartCoroutine(Play());

    private IEnumerator Play()
    {
        foreach (var slide in slides)
        {
            SlideChanged?.Invoke(slide);
            yield return new WaitForSeconds(/*slide.Message.Clip.length*/ 2);
        }

        _canSkip = false;
        _loader.LoadScene(_nextScene);
    }

    public void Skip()
    {
        if (_canSkip)
        {
            _canSkip = false;
            StopCoroutine(_playRoutine);
            _loader.LoadScene(_nextScene);
        }
    }
}

