using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Text brightnessTextUI = null;
   public PlayerManager playerManager;
    public Light sceneLight;
   // public Text brightnessTextUI = null;

    public void BrightnessSlider(float brightness)
    {
        brightnessTextUI.text = brightness.ToString("0.0");
        SaveBrightnessButton();
       
    }

    public void SaveBrightnessButton()
    {
        float brightnessValue = slider.value;
        PlayerPrefs.SetFloat("BrightnessValue", brightnessValue);
        LoadValues();
       
    }

    void LoadValues()
    {
        float brightnessValue = PlayerPrefs.GetFloat("BrightnessValue");
        slider.value = brightnessValue;
        
        sceneLight.intensity = brightnessValue;
       
        //RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }
    // Start is called before the first frame update
    void Start()
    {
        //float brightnessValue = slider.value;
      //  slider.value = brightnessValue;
        LoadValues();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
