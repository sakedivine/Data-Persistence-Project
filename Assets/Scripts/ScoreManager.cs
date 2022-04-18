using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string playerName = string.Empty;

    public int highScore = 0;
    public string championName = string.Empty;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class ScoreData
    {
        public int highScore;
        public string championName;
    }

    public void SaveData()
    {
        ScoreData data = new ScoreData();
        data.highScore = highScore;
        data.championName = championName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            highScore = data.highScore;
            championName = data.championName;
        }
    }
}
