
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuitButton : MonoBehaviour
{
    private QuitButton quitButton;
    // Start is called before the first frame update
    void Start()
    {
        quitButton = GetComponent<QuitButton>();
       // quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

