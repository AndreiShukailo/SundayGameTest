using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnLoadSceneButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
