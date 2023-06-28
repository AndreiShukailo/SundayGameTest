using UnityEngine;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private Sprite _sprite;
    private ButtonsHandler _buttonsHandler;
    private ImageLoader _imageLoader;

    private void Start()
    {
        _buttonsHandler = FindObjectOfType<ButtonsHandler>();
        _imageLoader = FindObjectOfType<ImageLoader>();
        Create();
    }

    private void Create()
    {
        _sprite = _image.sprite;
        _button.onClick.AddListener(OnImageClick);
        _button.onClick.AddListener(() => _buttonsHandler.OnLoadSceneButtonClick("View"));
    }

    private void OnImageClick()
    {
        _imageLoader.SetCurrentSprite( _sprite );
    }
}
