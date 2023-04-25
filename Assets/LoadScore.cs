using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class LoadScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     // gameObject.GetComponent<TextMeshProUGUI>().text += Utils.LoadPrefs("Score").ToString();
        string v = Utils.LoadPrefs("Score").ToString("N0", CultureInfo.InvariantCulture);
        gameObject.GetComponent<TextMeshProUGUI>().text += v;

    }

}
