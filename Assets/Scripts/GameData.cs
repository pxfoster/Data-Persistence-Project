using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// High score (saving data between sessions)
//     As the user plays, the current high score will be
//         displayed on the screen alongside the player
//         name who created the score.
//     If the high score is beaten, the new score and
//         player name will be displayed instead.
//     The highest score will be saved between sessions
//         so that if the player closes and reopens the
//         application, the high score and player name
//         will be retained.
//         
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
    }
}
