using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
public class LoadHighScore3 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    
        // gameObject.GetComponent<TextMeshProUGUI>().text += Utils.LoadPrefs("Score").ToString();
       string v=   Utils.LoadPrefs("HighScore3").ToString("N0",CultureInfo.InvariantCulture);
        gameObject.GetComponent<TextMeshProUGUI>().text += v;
        // a= string.Format(b, v);
        //  gameObject.GetComponent<TextMeshProUGUI>().text +=SaveData("score");
    }

}
