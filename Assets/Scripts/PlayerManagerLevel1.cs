using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerManagerLevel1 : MonoBehaviour
{
    //  public ScorePerSecond scorePerSecond;
    // public static bool gameOver;
    public Player player;
    public GameObject gameOverPanel;
  //  public static bool isGameStarted;
    public GameObject startingText;
    public Text coinsText;
    public Text applesText;
    public Text bananasText;
    public GameObject buttonPlay;
    public GameObject buttonPause;
    public GameObject gameOverText;
  //  public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.gameOver = false;
        PlayerManager.isGameStarted = false;
        Time.timeScale = 1;
        
        PlayerManager.numberOfGrapes = 0;
        PlayerManager.numberOfHamburgers = 0;
        PlayerManager.numberOfIcecreams = 0;
        PlayerManager.numberOfOranges = 0;
        PlayerManager.numberOfPizzas = 0;


    }


    // Update is called once per frame
    void Update()
    {
        if (Player.currentHealth < 0f || Player.currentHealth > 100f)
        {
            SaveCoins();
        }

        // dodelat podminku s narazem do prekazky

        if (PlayerManager.gameOver )
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverText.SetActive(true);
            buttonPause.SetActive(false);
            buttonPlay.SetActive(false);

        }

        coinsText.text = "Coins: " + PlayerManager.numberOfCoins;
        applesText.text = "Apples: " + PlayerManager.numberOfA;
        bananasText.text = "Bananas: " + PlayerManager.numberOfBananas;
      //  ScoreText.text = "Score: " + ScorePerSecond.scoreAmount;



        if (SwipeManager.tap)
        {
            PlayerManager.isGameStarted = true;
            Destroy(startingText);
        }


    }

    public void SaveCoins()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Coins", PlayerManager.numberOfCoins.ToString()},
                {"Apples", PlayerManager.numberOfA.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Seccessful user data send!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

}
