using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 5f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isGameStarted == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delayBeforeLoading) //novy kus kodu
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
        }
    }
}
