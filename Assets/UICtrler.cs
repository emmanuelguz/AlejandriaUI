using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UICtrler : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
   

    // Start is called before the first frame update
    void Start()
    {
        

        
        restartButton.clicked += RestartButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    void QuitButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    void RestartButtonPressed()
    {
        Invoke("Reset", 1.5f);
        
    }
    private void Reset()
    {
        Time.timeScale = 1f;
        Player.Lives = 3;
        SceneManager.LoadScene("DiverGame");
    }

    

}
