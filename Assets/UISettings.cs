using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class UISettings : MonoBehaviour
{

    public Action Back { set => _back.clicked += value; }
    
    private Slider _gral;
    private Slider _musica;
    private Slider _sfx;
    private Button _back;
    public AudioMixer gralMixer;
    // Start is called before the first frame update
  

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _gral = root.Q<Slider>("Slider_Gral");
        _musica = root.Q<Slider>("Slider_Musica");
        _sfx = root.Q<Slider>("Slider_SFX");
        _back = root.Q<Button>("quitbutton");

        _gral.RegisterValueChangedCallback(OnSliderValueChanged);
        _musica.RegisterValueChangedCallback(OnSliderValueChanged);
        _sfx.RegisterValueChangedCallback(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(ChangeEvent<float> changeEvent)
    {
        if (changeEvent.target == _gral)
        {            
            gralMixer.SetFloat("General", _gral.value);
        }
        else if (changeEvent.target == _sfx)
        {            
            gralMixer.SetFloat("SFX", _sfx.value);
        }
        else if (changeEvent.target == _musica)
        {
            gralMixer.SetFloat("Music", _musica.value);
        }
    }

}

