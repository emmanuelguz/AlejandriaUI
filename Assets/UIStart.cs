using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class UIStart 
{
    public Action OpenSettings { set => _settings.clicked += value; }
    private Button _start;
    private Button _settings;
    private Button _quit;


    public UIStart(VisualElement root)
    {               
        _start = root.Q<Button>("restart");
        _settings = root.Q<Button>("settings");
        _quit = root.Q<Button>("quit");
    }
    
    private void ButtonLogs()
    {
        _start.clicked += Reset;
        _settings.clicked += QuitButtonPressed;
        _quit.clicked += QuitButtonPressed;
    }   
    void QuitButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    
    private void Reset()
    {
        Time.timeScale = 1f;
        Player.Lives = 3;
        SceneManager.LoadScene("DiverGame");
    }

}
