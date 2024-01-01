using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
