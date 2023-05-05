using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIDisplayer : MonoBehaviour
{
    //Elementos inGame
    public Text lifesDisp;
    public Text scoreDisp;
    public float resetDelay;

    //Elementos Game Over Menu
    public GameObject PanelMenu;
    public GameObject PanelUser;
    public static bool gamePaused = false;

    int _amount = 1;
    float _score = 0;


    //Start is called before the first frame update
    void Start()
    {
        PanelMenu.SetActive(false);
        PanelUser.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Player.Lives < 1)
        {
            Pause();
            Player.Lives = 0;
        }
        //InGame
        lifesDisp.text = "Vidas: " + Player.Lives.ToString();
        scoreDisp.text = "Puntos: " + (int)_score;
        _score += _amount * Time.deltaTime;
        Player.score = (int)_score;

    }
    public void Resume()
    {
        gamePaused = false;
        Cursor.visible = false;
        PanelMenu.SetActive(false);
        PanelUser.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        gamePaused = true;
        Cursor.visible = true;
        PanelMenu.SetActive(true);
        PanelUser.SetActive(false);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {

    }
    public void Restart()
    {
        gamePaused = false;
        Invoke("Reset", resetDelay);
    }
    private void Reset()
    {
        Time.timeScale = 1f;
        Player.Lives = 3;
        SceneManager.LoadScene("DiverGame");
    }
}
