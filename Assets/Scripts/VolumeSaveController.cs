using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider = null;
       //  [SerializeField] private Text volumeTextUI = null;

    public void VolumeSlider(float volume)
    {
        //volumeTextUI.text = volume.ToString("0.0");
        SaveVolumeButton();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
       float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        float volumeValue = volumeSlider.value;
        volumeSlider.value = volumeValue;
        // chtela jsem udelat default na 0.3f na zacatek, ale zatim to nejde
      //  volumeValue = 0.3f;
       
        LoadValues();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
