using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class UIMain : MonoBehaviour
{
    public VisualElement settingView;
    public VisualElement mainView;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        mainView = root.Q("StartMenu");
        settingView = root.Q("Settings");

        SetUpStartMenu();
       // SetUpSettingsMenu();
    }

    private void SetUpStartMenu()
    {
        UIStart shoMenu = new UIStart(mainView);
        shoMenu.OpenSettings = () => ToggleSettingsMenu(true);
    }
    //private void SetUpSettingsMenu()
    //{
    //    UISettings shoMenu = new UISettings(settingView);
    //    shoMenu.Back = () => ToggleSettingsMenu(false);
    //}

    private void ToggleSettingsMenu( bool enable)
    {
        mainView.Display(!enable);
        settingView.Display(enable);        
    }

}
