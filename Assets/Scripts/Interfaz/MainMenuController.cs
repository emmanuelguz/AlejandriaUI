using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject minigamesMenu;
    public GameObject optionsMenu;
    public GameObject confirmPanel;

    //metodo para ir al menu de opciones
    public void ShowOptionMenu(bool show)
    {
        optionsMenu.SetActive(show);
        mainMenu.SetActive(!show);
    }

    //Metodo para ir al menu de minijuegos
    public void ShowMinigamesMenu(bool show)
    {
        minigamesMenu.SetActive(show);
        mainMenu.SetActive(!show);
    }

    //Metodo para mostrar el panel de confirmacion para salir
    public void ShowConfirmPanel(bool show)
    {
        confirmPanel.SetActive(show);
        mainMenu.SetActive(!show);
    }

    //Metodo para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }

    //Metodo para ir al juego del mecanico
    public void CarMechanicGame()
    {
        SceneManager.LoadScene("CarMechanic");
    }

    //Metodo para ir al juego del cartero
    public void PostmanGame()
    {
        SceneManager.LoadScene("Postman");
    }

    //Metodo para ir al juego del buzo
    public void DiverGame()
    {
        SceneManager.LoadScene("DiverGame");
    }
}
