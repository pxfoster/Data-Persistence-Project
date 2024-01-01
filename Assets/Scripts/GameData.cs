using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string PlayerName;
    public string[] BestScoreNames;
    public int[] BestScores;
    public Color[] BrickColors;

    private const int MaxNumHighScores = 5;
    private const int MaxNumBrickColors = 3;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        BestScoreNames = new string[MaxNumHighScores];
        BestScores = new int[MaxNumHighScores];
        
        BrickColors = new Color[MaxNumBrickColors];
        BrickColors[0] = Color.green;
        BrickColors[1] = new Color(1, 1, 0);
        BrickColors[2] = Color.blue;

        LoadGameData();
    }

    public int GetMaxNumHighScores()
    {
        return MaxNumHighScores;
    }

    public void UpdateScoresList(string newName, int newScore)
    {
        int index = GetScoresIndexToUpdate(newScore);

        if (index != -1)
        {
            for (int i = MaxNumHighScores - 1; i > index; i--)
            {
                BestScoreNames[i] = BestScoreNames[i - 1];
                BestScores[i] = BestScores[i - 1];
            }

            BestScoreNames[index] = newName;
            BestScores[index] = newScore;
        }
    }

    private int GetScoresIndexToUpdate(int newScore)
    {
        for(int i = 0; i < MaxNumHighScores; i++)
        {
            if (newScore > BestScores[i])
                return i;
        }

        return -1;
    }

    [Serializable]
    class SaveData
    {
        public string[] BestScoreNames;
        public int[] BestScores;
        public Color[] BrickColors;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.BestScoreNames = new string[MaxNumHighScores];
        data.BestScores = new int[MaxNumHighScores];
        data.BrickColors = new Color[MaxNumBrickColors];

        for (int i = 0; i < MaxNumHighScores; i++)
        {
            data.BestScoreNames[i] = BestScoreNames[i];
            data.BestScores[i] = BestScores[i];
        }

        for(int i = 0; i < MaxNumBrickColors; i++)
        {
            data.BrickColors[i] = BrickColors[i];
        }

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

            for (int i = 0; i < MaxNumHighScores; i++)
            {
                BestScoreNames[i] = data.BestScoreNames[i];
                BestScores[i] = data.BestScores[i];
            }

            for (int i = 0; i < MaxNumBrickColors; i++)
            {
                BrickColors[i] = data.BrickColors[i];
            }
        }
    }
}
