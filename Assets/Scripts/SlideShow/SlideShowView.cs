using TMPro;
using UnityEngine;
using Zenject;

public sealed class SlideShowView : MonoBehaviour
{
    [Inject] private ISlideShow _slideShow;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() => _slideShow.SlideChanged += OnSlideChanged;

    private void OnDisable() => _slideShow.SlideChanged -= OnSlideChanged;

    private void OnSlideChanged(Slide slide) => _text.text = slide.Message.Text;
}
