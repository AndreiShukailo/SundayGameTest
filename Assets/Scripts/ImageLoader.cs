using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private string _baseURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    [SerializeField] private int _imageCount;
    [SerializeField] private int _preloadImageNumber = 10;
    public Sprite CurrentSprite { get; private set; }
    public List<Sprite> UploadedImages { get; private set; } = new List<Sprite>();
    public float PreloadProgress { get; private set; }

    public UnityAction<Sprite> OnNewImageLoaded;
    private bool _loadingStarted = false;

    private void Start()
    {
        gameObject.SetActive(false);

        if (FindObjectOfType<ImageLoader>() == null)
        {
            gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartLoadingImages()
    {
        if (!_loadingStarted)
            StartCoroutine(StartLoading());
    }

    public void SetCurrentSprite(Sprite sprite)
    {
        CurrentSprite = sprite;
    }

    IEnumerator StartLoading()
    {
        _loadingStarted = true;
        for (int i = 1; i <= _imageCount; i++)
        {
            yield return StartCoroutine(LoadImage(i));
        }
    }

    IEnumerator LoadImage(int imageId)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture($"{_baseURL}{imageId}.jpg"))
        {
            uwr.SendWebRequest();

            while (!uwr.isDone)
            {
                if (imageId <= _preloadImageNumber)
                {
                    PreloadProgress = ((imageId - 1f) * (1f / _preloadImageNumber)) + (uwr.downloadProgress / _preloadImageNumber);
                }
                yield return null;
            }

            if (uwr.isDone)
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                var newSprite = Sprite.Create(uwrTexture, new Rect(0.0f, 0.0f, uwrTexture.width, uwrTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                UploadedImages.Add(newSprite);
                OnNewImageLoaded?.Invoke(newSprite);
            }
        }
    }
}
