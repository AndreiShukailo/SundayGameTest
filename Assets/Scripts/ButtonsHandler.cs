using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    private Navigation _navigation;

    private void Start()
    {
        _navigation = FindObjectOfType<Navigation>();
    }

    public void OnLoadSceneButtonClick(string sceneName)
    {
        _navigation.LoadScene(sceneName);
    }
}
