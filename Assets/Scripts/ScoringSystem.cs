using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static float difficulty { get; set; } = 1f;
    public static ScoringSystem current;

    int currentScore;
    int currentLives;

    void Awake()
    {
        current = this;

        currentScore = PlayerPrefs.GetInt("current_score", 0);
        currentLives = PlayerPrefs.GetInt("current_lives", 3);

        if (currentLives < 0)
        {
            currentLives = 0;
        }

        PlayerPrefs.SetInt("current_score", currentScore);
        PlayerPrefs.SetInt("current_lives", currentLives);

        Debug.Log("Current Lives : " + currentLives + ", Current Score : " + currentScore + " -SCORING SYSTEM");
    }

    public void SaveScore(bool result, int Addedscore)
    {
        currentScore += Addedscore;
        PlayerPrefs.SetInt("current_score", currentScore);

        if (result)
        {
            PlayerPrefs.SetInt("current_lives", currentLives);
        }
        else
        {
            if (currentLives > 0)
            {
                PlayerPrefs.SetInt("current_lives", --currentLives);
            }
            else
            {
                PlayerPrefs.SetInt("current_lives", 0);
            }
        }

        GlobalEvent.current.LateLevelEnd(result, Addedscore);

        Debug.Log("SaveScore duluan");
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey("current_score");
        PlayerPrefs.DeleteKey("current_lives");
    }
}
