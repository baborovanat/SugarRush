using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class LoadHighScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       

        string v = Utils.LoadPrefs("HighScore").ToString("N0", CultureInfo.InvariantCulture);
        gameObject.GetComponent<TextMeshProUGUI>().text += v;
    }

}
