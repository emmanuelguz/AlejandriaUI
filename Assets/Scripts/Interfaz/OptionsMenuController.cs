using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject audioSection;
    public GameObject videoSection;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;

    private int width;
    private int height;

    private void Awake()
    {
        //Inicializa la configuracion

    }

    //Metodo para mostrar la seccion de audio
    public void ShowAudioSection(bool show)
    {
        audioSection.SetActive(show);
        videoSection.SetActive(!show);
    }

    //Metodo para mostrar la seccion de video
    public void ShowVideoSection(bool show)
    {
        videoSection.SetActive(show);
        audioSection.SetActive(!show);
    }

    //Metodo para actualizar la configuracion de sonido
    public void ApplyAudioConfigurations()
    {
        //Volumen
        AudioListener.volume = volumeSlider.value;
    }

    //Metodo para actualizar la resolucion
    public void SetResolution()
    {
        string resolutionText = resolutionDropdown.captionText.text;
        string[] resolution = resolutionText.Split('x');
        width = int.Parse(resolution[0]);
        height = int.Parse(resolution[1]);
    }

    //Metodo para aplicar la configuracion de video
    public void ApplyVideoConfiguration()
    {
        //Fullscreen
        Screen.fullScreen = fullscreenToggle;
        Screen.SetResolution(width, height, fullscreenToggle);
    }

    private void OnEnable()
    {
        //Inicializa la configuracion de video
        width = Screen.width;
        height = Screen.height;
        fullscreenToggle.isOn = Screen.fullScreen;

        for(int i=0; i<resolutionDropdown.options.Count; i++)
        {
            if (resolutionDropdown.options[i].text.Equals(width + "x" + height))
                resolutionDropdown.value = i;
        }
    }
}
