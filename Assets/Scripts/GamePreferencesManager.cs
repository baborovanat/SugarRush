using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferencesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();
    }

    // Update is called once per frame
    void Update()
    {
       SavePrefs();
    }

   public void LoadPrefs()
    {
      PlayerPrefs.SetFloat("CurrentPlayerHealth", Player.currentHealth);
        PlayerPrefs.Save();
    }

  public  void SavePrefs()
    {
        var score = PlayerPrefs.GetFloat("CurrentPlayerHealth");
       Player.currentHealth = score;
    }
}
