using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
//using Newtonsoft.Json;
public class ScorePerSecondLevel2 : MonoBehaviour
{
    public Text ScoreText;
    public static float scoreAmount;
    public float pointIncreasedPerSecond;
    public Player player;
    ScorePerSecondLevel1 scorePerSecondLevel1;
    ScorePerSecond scorePerSecond;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = ScorePerSecondLevel1.scoreAmount;
        pointIncreasedPerSecond = 1f;
        ScoreText.text = "Score: " + (int)ScorePerSecondLevel1.scoreAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.currentHealth < 0f || Player.currentHealth > 100f)
        {
           // SaveScore();
            // NewScore2();

            if (ScorePerSecondLevel2.scoreAmount > ScorePerSecond.scoreAmount)
            {
               SaveScore();
               NewScore2();
            }
           
           


        }

        if (PlayerManager.isGameStarted && (Player.currentHealth > 1f && Player.currentHealth < 25f))
        {

            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

        }
        else
        {
            scoreAmount += 0;
        }


        if (PlayerManager.isGameStarted)
        {
            ScoreText.text = "Score: " + (int)scoreAmount; //pretypovani
         //   scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            // scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            Utils.SavePrefs("Score", scoreAmount);

            //nacist highscore
            var currentHighScore = Utils.LoadPrefs("HighScore");
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
                {"Score_2", Mathf.Floor(scoreAmount).ToString() }
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
    public void NewScore2()
    {
        var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "newScore2",
            FunctionParameter = new
            {
                name = PlayfabManager.emailInputString,
                score = Mathf.Floor(scoreAmount).ToString()
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess6, OnError);
    }
    void OnExecuteSuccess6(ExecuteCloudScriptResult result)
    {
        Debug.Log("new score2");
    }
}