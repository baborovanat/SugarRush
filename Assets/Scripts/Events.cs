

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
   public PlayerController playerController;
    public PlayerManager playerManager;
    public GameObject gameOverPanel;
    public GameObject buttonPlay;
    public GameObject buttonPause;

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ReplayGame1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ReplayGame2()
    {
        SceneManager.LoadScene("Level2");
    }

    public static void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ViewMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void ViewMenuLogin()
    {
        //tohle udelat v playfab manager
        
        SceneManager.LoadScene("Menu");

    }

    public void Pause()
    {
        PlayerManager.isGameStarted = false;
        gameOverPanel.SetActive(true);
        buttonPlay.SetActive(true);
        buttonPause.SetActive(false);
       // Time.timeScale = 0.0f*Time.fixedDeltaTime;
       // playerController.forwardSpeed = 0.0f*Time.fixedDeltaTime;

    }

    public void Play()
    {
        PlayerManager.isGameStarted = true;
        gameOverPanel.SetActive(false);
        buttonPlay.SetActive(false);
        buttonPause.SetActive(true);
        // Time.timeScale = 0.0f*Time.fixedDeltaTime;
        // playerController.forwardSpeed = 0.0f*Time.fixedDeltaTime;

    }


}


