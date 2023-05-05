using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMan : MonoBehaviour
{
    public static GameMan instance = null;
    public GameObject mainMenu;
    public GameObject resetGame;
    public float resetDelay;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    public void RoundEnd()
    {
        mainMenu.SetActive(true);        
        Invoke("Reset", resetDelay);
    }
    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DiverGame");            
    }

}
