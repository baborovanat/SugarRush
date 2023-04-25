using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject optionsPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public Text coinsText;
    public Text applesText;
    public Text bananasText;
    public Events events;
    public GameObject buttonPlay;
    public GameObject buttonPause;
    public GameObject gameOverText;
    //  public Text ScoreText;

    public static int numberOfCoins;
    public static int numberOfA;
    public static int numberOfBananas;
    public static int numberOfGrapes;
    public static int numberOfOranges;
    public static int numberOfPizzas;
    public static int numberOfHamburgers;
    public static int numberOfIcecreams;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        numberOfA = 0;
        numberOfBananas = 0;
        numberOfGrapes = 0;
        numberOfHamburgers = 0;
        numberOfIcecreams = 0;
        numberOfOranges = 0;
        numberOfPizzas = 0;


    }


    // Update is called once per frame
    void Update()
    {
        if (Player.currentHealth < 0f || Player.currentHealth > 100f)
        {
            SaveCoins();
        }

        // dodelat podminku s narazem do prekazky
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            buttonPause.SetActive(false);
            buttonPlay.SetActive(false);
            gameOverText.SetActive(true);
            //  SaveCoins();    

        }


        coinsText.text = "Coins: " + numberOfCoins;
        applesText.text = "Apples: " + numberOfA;
        bananasText.text = "Bananas: " + numberOfBananas;
        //ScoreText.text = "Score: " + ScorePerSecond.scoreAmount;



        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }

    }

    public void SaveCoins()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Coins", numberOfCoins.ToString()},
                {"Apples", numberOfA.ToString() }
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
    public void OpenOPtionsPanel()
    {
        optionsPanel.SetActive(true);
        isGameStarted = false;
    }

    public void OpenGameOverPanel()
    {
        optionsPanel.SetActive(false);
        isGameStarted = false;
        //todo
        //nejaky while cyklus, while optionspanel.setactive(true) isgamestarted=false
    }
   
}
