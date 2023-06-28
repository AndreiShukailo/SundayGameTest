using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject _raw;
    [SerializeField] private Image _image;
    [SerializeField] private Transform _content;

    private ImageLoader _loader;
    private bool _rawIsFull = true;
    private GameObject _lastRaw;

    private void Start()
    {
        _loader = FindObjectOfType<ImageLoader>();
        _loader.OnNewImageLoaded += AddNewImage;
        CreatePreloadedGallery();
    }

    private void AddNewImage(Sprite sprite)
    {
        if (_rawIsFull)
        {
            var newRaw = Instantiate(_raw, _content);
            _lastRaw = newRaw;
            _rawIsFull = false;
        }
        else
        {
            _rawIsFull = true;
        }

        Image newImage = Instantiate(_image, _lastRaw.transform);
        newImage.sprite = sprite;
    }

    private void CreatePreloadedGallery()
    {
        foreach (var item in _loader.UploadedImages)
        {
            AddNewImage(item);
        }
    }

    private void OnDestroy()
    {
        _loader.OnNewImageLoaded -= AddNewImage;
    }
}
