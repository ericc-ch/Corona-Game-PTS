using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelMenu : MonoBehaviour
{
    public GameObject endPanel;
    public Text scoreText;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        TimeManager.localTimeScale = 1f;
    }

    public void Show(bool result, int score)
    {
        int currentScore = PlayerPrefs.GetInt("current_score", 0);
        int currentLives = PlayerPrefs.GetInt("current_lives", 0);

        if (result)
        {
            PauseAndShow();
        }
        else
        {
            PauseAndShow();
        }
    }

    void PauseAndShow()
    {
        TimeManager.localTimeScale = 0f;
        endPanel.SetActive(true);
    }

    public void UpdateScore()
    {
        int currentScore = PlayerPrefs.GetInt("current_score", 0);

        scoreText.text = "Skor: " + currentScore;
    }

    public void PlaySound(bool result, int score)
    {
        if (!result)
        {
            audioSource.Play();
        }
    }

}
