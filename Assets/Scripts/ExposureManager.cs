using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposureManager : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
   [SerializeField] private float exposure;
  //  [SerializeField] private Text brightnessTextUI = null;
   public PlayerManager playerManager;
   // public Light sceneLight;
    //  public Slider slider;
    //public Light sceneLight;
    // public Text brightnessTextUI = null;
    //vyzkouset if else se svetlem za kamerou

    public void BrightnessSlider(float exposure)
    {
        //brightnessTextUI.text = exposure.ToString("0.0");
        SaveBrightnessButton();
        
        // if (exposure == 0.1f)
        // {
        // sceneLight.intensity = 0.0f;
        //   }

    }

    public void SaveBrightnessButton()
    {
        float exposureValue = slider.value;
        PlayerPrefs.SetFloat("ExposureValue", exposureValue);
        LoadValues();
        

    }

    void LoadValues()
    {
        float exposureValue = PlayerPrefs.GetFloat("ExposureValue");
        slider.value = exposureValue;
        
        // sceneLight.intensity = exposureValue;

        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        exposure = exposureValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        // float brightnessValue = slider.value;
        //slider.value = brightnessValue;
        LoadValues();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
