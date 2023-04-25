using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private ScoreData _ScoreData = new ScoreData();

    public void SaveIntoJson()
    {
        string _score = JsonUtility.ToJson(_ScoreData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/ScoreData.json", _score);
    }
}

[System.Serializable]
public class ScoreData
{
    //public string potion_name;
    //public int value;
    public List<Score> score = new List<Score>();
}

[System.Serializable]
public class Score
{
    public float score;
}