using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameMenuManager : MonoBehaviour
{
    //Atributos
    public static MinigameMenuManager instance;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject victoryMenu;

    private bool isPaused = false;
    private bool gameOver = false;

    private void Awake()
    {
        //Singleton
        instance = this;
    }

    private void Update()
    {
        //Si se presiona la tecla para pausar y no se ha terminado el juego
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        Debug.Log(Time.timeScale);
    }

    //Metodo para activar/desactivar el menu de gameover
    public void GameOverMenu()
    {
        if (!gameOver)
        {
            //Desactiva el menu de pausa y activa el menu de GameOver
            pausePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            gameOver = true;
            Time.timeScale = 0f;
        }
    }

    //Metodo para activar el menu de victoria
    public void VictoryMenu()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //Metodo para reiniciar
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Metodo para salir
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    //Metodo para reanudar el juego
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Metodo para pausar el juego
    private void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //Metodo para saber si esta pausado o no
    public bool IsPaused
    {
        get { return isPaused; }
    }

    //Metodo para saber si el juego tiene el menu gameover
    public bool GameOver
    {
        get { return gameOver; }
    }
}
