using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class LoadHighScore2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       

        string v = Utils.LoadPrefs("HighScore2").ToString("N0", CultureInfo.InvariantCulture);
        gameObject.GetComponent<TextMeshProUGUI>().text += v;
    }

}
