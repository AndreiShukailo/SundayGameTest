using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        if (Screen.orientation != ScreenOrientation.Portrait)
            Screen.orientation = ScreenOrientation.Portrait;

        var loader = FindObjectOfType<ImageLoader>();
        var navigation = FindObjectOfType<Navigation>();
        if (navigation != null)
            LoadLevel(navigation.CurrentScene, loader);
        else Debug.LogError("Not found Navigation");

    }

    public void LoadLevel(string sceneName, ImageLoader loader)
    {
        StartCoroutine(LoadAsynchronously(sceneName, loader));
    }

    IEnumerator LoadAsynchronously(string sceneName, ImageLoader loader)
    {
        var progress = 0f;

        if (sceneName == "Gallery")
        {
            loader.StartLoadingImages();
            while (loader.PreloadProgress < 1f)
            {
                progress = loader.PreloadProgress * 0.8f;
                FillSlider(progress);
                yield return null;
            }
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            progress = loader.PreloadProgress * 0.8f + Mathf.Clamp01(operation.progress) * 0.2f;
            FillSlider(progress);
            yield return null;
        }

    }

    private void FillSlider(float progress)
    {
        _slider.value = progress;
        _text.text = string.Format("{0:00} %", _slider.value * 100);
    }
}
