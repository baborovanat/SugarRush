using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class ScorePerSecond : MonoBehaviour
{
    //dodelat odeslani skore po narazu do prekazky
    public Text ScoreText;
    public Text HighScoreText;
    public static float scoreAmount;
    public float pointIncreasedPerSecond;
    public Player player;
    public static int scoreAmountInt;
    PlayfabManager playfabManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0;
        pointIncreasedPerSecond = 1f;
        
    }
   


    // Update is called once per frame
    void Update()
    {
        scoreAmountInt = (int)scoreAmount;

        if (Player.currentHealth < 0f || Player.currentHealth > 100f)
        {
            SaveScore();
            
            NewScore();
            SendLeaderboard(scoreAmountInt);//dodelat skore
        }

        if (PlayerManager.isGameStarted && (Player.currentHealth > 1f && Player.currentHealth < 25f))
        {
           // ScoreText.text = "Score: " + (int)scoreAmount;
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            Debug.Log($"ScoreInt {scoreAmountInt} ");
           
            // Utils.SavePrefs("Score", scoreAmount);
        }
        else
        {
            scoreAmount += 0;
        }

        if (PlayerManager.isGameStarted )
       {
       
           ScoreText.text = "Score: " + (int)scoreAmount; //pretypovani
           // scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
           Utils.SavePrefs("Score", scoreAmount);

            //nacist highscore
            var currentHighScore = Utils.LoadPrefs("HighScore") ;
            var currentHighScore2 = Utils.LoadPrefs("HighScore2");
            var currentHighScore3 = Utils.LoadPrefs("HighScore3");
            //zaokrouhlit
            var zaokrouhlena = Mathf.Floor(currentHighScore);
            var zaokrouhlena2 = Mathf.Floor(currentHighScore2);
            var zaokrouhlena3 = Mathf.Floor(currentHighScore3);
            // porovnat aktualni score a highscore
            if (scoreAmount > zaokrouhlena)
            {
                Utils.SavePrefs("HighScore", scoreAmount);
            }
            if (scoreAmount < zaokrouhlena && scoreAmount > zaokrouhlena2)
            {
                Utils.SavePrefs("HighScore2", scoreAmount);
            }
            if (scoreAmount < zaokrouhlena && scoreAmount < zaokrouhlena2 && scoreAmount > zaokrouhlena3)
            {
                Utils.SavePrefs("HighScore3", scoreAmount);
            }

        }
        
    }

    public void SaveScore()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Score", Mathf.Floor(scoreAmount).ToString() }
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


    public  void NewScore()
    {
       

            var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "newScore",
            FunctionParameter = new
            {
                name = PlayfabManager.emailInputString,
                score = Mathf.Floor(scoreAmount).ToString()
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess4, OnError);
    }

    void OnExecuteSuccess4(ExecuteCloudScriptResult result)
    {
        Debug.Log("new score");
    }

    public void SendLeaderboard(int score) //zmenit
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }

}
