using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField] List<Text> Names;
    [SerializeField] List<Text> Scores;

    void Start()
    {
        for(int i = 0; i < GameData.Instance.GetMaxNumHighScores(); i++)
        {
            Names[i].text = GameData.Instance.BestScoreNames[i];
            Scores[i].text = GameData.Instance.BestScores[i].ToString();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
