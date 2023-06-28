using UnityEngine;

public class OrientationManager : MonoBehaviour
{
    [SerializeField] private GameObject _portraitUI;
    [SerializeField] private GameObject _landscapeUI;

    private void Update()
    {
        var orientation = Input.deviceOrientation;
        SetOrientation(orientation);
    }

    private void SetOrientation(DeviceOrientation orientation)
    {
        switch (orientation)
        {
            case DeviceOrientation.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                ActivePortrait();
                break;
            case DeviceOrientation.PortraitUpsideDown:
                Screen.orientation = ScreenOrientation.PortraitUpsideDown;
                ActivePortrait();
                break;
            case DeviceOrientation.LandscapeLeft:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                ActiveLandscape();
                break;
            case DeviceOrientation.LandscapeRight:
                Screen.orientation = ScreenOrientation.LandscapeRight;
                ActiveLandscape();
                break;
        }
    }
    private void ActivePortrait()
    {
        _portraitUI.SetActive(true);
        _landscapeUI.SetActive(false);
    }

    private void ActiveLandscape()
    {
        _portraitUI.SetActive(false);
        _landscapeUI.SetActive(true);
    }
}
