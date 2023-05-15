using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private float speed;
   // [SerializeField] private Text speedTextUI = null;
    public PlayerController playerController;
    // Start is called before the first frame update

    public void SpeedSlider(float brightness)
    {
       // speedTextUI.text = brightness.ToString("0.0");
        SaveSpeedButton();
    }

    public void SaveSpeedButton()
    {
        float speedValue = slider.value;
        PlayerPrefs.SetFloat("SpeedValue", speedValue);
        LoadValues();
    }

    void LoadValues()
    {
        float speedValue = PlayerPrefs.GetFloat("SpeedValue");
        slider.value = speedValue;
        playerController.forwardSpeed = speedValue;
    }

    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
