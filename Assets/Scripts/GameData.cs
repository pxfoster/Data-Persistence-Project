using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// TODO:
// Optional:
//     Create a separate High Score scene that displays
//         the high score.
//     Display multiple high scores instead of just one.
//     Create a Settings scene that allows users to
//         configure gameplay, and use that information
//         between sessions.

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string PlayerName;
    public string BestScoreName;
    public int BestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.BestScoreName = BestScoreName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScoreName = data.BestScoreName;
            BestScore = data.BestScore;
        }
    }
}
