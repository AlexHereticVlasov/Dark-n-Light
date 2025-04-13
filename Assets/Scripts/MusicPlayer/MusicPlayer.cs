using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _playList;

    private int _index;
    private float _time;
    private Coroutine _playRoutine;

    private event UnityAction TrackOver;

    public static MusicPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Play();
            return;
        }

        Destroy(gameObject);
    }

    private void OnEnable() => TrackOver += OnTrackOver;

    private void OnDisable() => TrackOver -= OnTrackOver;

    private void OnTrackOver()
    {
        _index++;
        _index %= _playList.Length;

        StartCoroutine(PlayRoutine());
    }

    public void Play()
    {
        _playRoutine = StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        _source.clip = _playList[_index];
        _source.Play();

        float length = _source.clip.length - _source.time;
        yield return new WaitForSeconds(length);

        TrackOver?.Invoke();
    }

    private IEnumerator FadeIn()
    {
        _source.time = _time;

        yield return null;
    }

    private IEnumerator FadeOut()
    {
        _time = _source.time;

        yield return null;
    }
}
