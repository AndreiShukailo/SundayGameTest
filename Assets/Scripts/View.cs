using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private Image _image;

    private ImageLoader _loader;

    private void Start()
    {
        _loader = FindObjectOfType<ImageLoader>();
        _image.sprite = _loader.CurrentSprite;
    }
}
