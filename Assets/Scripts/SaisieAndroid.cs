using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaisieAndroid : MonoBehaviour
{
    TouchScreenKeyboard clavier;
    // Start is called before the first frame update
    public void OpenKeyboard()
    {
        clavier = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
