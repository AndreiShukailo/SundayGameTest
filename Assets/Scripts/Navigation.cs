using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public string CurrentScene { get; private set; }

    private void Start()
    {
        gameObject.SetActive(false);

        if (FindObjectOfType<Navigation>() == null)
        {
            gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (CurrentScene != "Loading" || CurrentScene != "Menu")
        {
            if (Input.GetButton("Cancel"))
            {
                switch (CurrentScene)
                {
                    case "Gallery":
                        LoadScene("Menu");
                        break;
                    case "View":
                        LoadScene("Gallery");
                        break;
                }
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        CurrentScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
}
