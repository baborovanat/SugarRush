

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ private QuitButton quitButton;
   void Start()
    { 
        quitButton = GetComponent<QuitButton>();
        //quitButton.onClick.AddListener(QuitGame);
    }

    public void ViewStats()
    {
        SceneManager.LoadScene("Stats");

    }

    public void ViewScore()
    {
        SceneManager.LoadScene("StScore");

    }

    public void ViewSettings()
    {
        SceneManager.LoadScene("Options");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");

    }

    public void Login()
    {
        SceneManager.LoadScene("Login");
    }

    public void Feedback()
    {
        SceneManager.LoadScene("Feedback");
    }
        
    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
        Application.Quit();
    }

   }

