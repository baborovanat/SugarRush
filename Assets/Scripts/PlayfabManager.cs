using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
   

    [Header("UI")]
    public Text messageText;
    public TMP_InputField emailInput;
    public static string emailInputString;
    public TMP_InputField passwordInput;
    public Text output;
    public TMP_InputField topicInput;
    public TMP_InputField messageInput;

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }

    public void RegisterButton()
    {
     if(passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short! Must be at least 6 characters";
            return;
        }
        
        var request = new RegisterPlayFabUserRequest
        {
            
 Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

       
    }


    void OnExecuteSuccess(ExecuteCloudScriptResult result)
    {
        output.text = result.FunctionResult.ToString();
    }

    void OnExecuteSuccess2(ExecuteCloudScriptResult result)
    {
        Debug.Log("new discord message");
    }

    void OnExecuteSuccess3(ExecuteCloudScriptResult result)
    {
        Debug.Log("new feedback");
    }

    void OnExecuteSuccess4(ExecuteCloudScriptResult result)
    {
        Debug.Log("new score");
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "3F8DC"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset e-mail sent";
    }
    // Start is called before the first frame update
    void Start()
    {
    //    Login();
   
       
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    //  void Login()
    // {
    //    var request = new LoginWithCustomIDRequest
    //  {
    //       CustomId = SystemInfo.deviceUniqueIdentifier,
    //       CreateAccount = true
    //   };
    // PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    //}

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in";
        StartCoroutine(WaitForSceneLoad());

        var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "newUserRegistered",
            FunctionParameter = new
            {
                name = emailInput.text
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess2, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful log in");
        GetCharacters();
        StartCoroutine(WaitForSceneLoad());
        emailInputString += emailInput.text;
        Debug.Log($"mail: {emailInputString}");

        var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "hello",
            FunctionParameter = new
            {
                name = emailInput.text
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess, OnError);

        
    }

    void OnError(PlayFabError error) 
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public void GetCharacters()
    {

    }

    public void SendFeedback()
    {
        var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "sendFeedback",
            FunctionParameter = new
            {
                topic = topicInput.text,
                message = messageInput.text,
                name = emailInput.text
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess3, OnError);
    }


}

