using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField playerName;
    [SerializeField] Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (GameData.Instance.BestScore > 0)
        {
            highScore.text = $"Best Score : {GameData.Instance.BestScoreName} : {GameData.Instance.BestScore}";
        }

        if (GameData.Instance.PlayerName != "Anon")
        {
            playerName.text = GameData.Instance.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameData.Instance.PlayerName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameData.Instance.SaveGameData();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
