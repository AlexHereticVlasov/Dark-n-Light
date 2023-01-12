using UnityEngine;
using Zenject;

public sealed class SlideShowView : MonoBehaviour
{
    [Inject] private SlideShow _slideShow;

    private void OnEnable() => _slideShow.SlideChanged += OnSlideChanged;

    private void OnDisable() => _slideShow.SlideChanged -= OnSlideChanged;

    private void OnSlideChanged(Slide slide)
    {
        
    }
}
