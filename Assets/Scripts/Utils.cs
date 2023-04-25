using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Utils 
{
    public static void SavePrefs(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);     
    }
    public static float LoadPrefs(string key)
    {
       return PlayerPrefs.GetFloat(key);
       
    }
}
