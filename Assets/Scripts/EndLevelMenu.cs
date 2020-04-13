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

        TimeManager.localTimeScale = 0f;
        endPanel.SetActive(true);

        if (!result)
        {
            audioSource.Play();
        }

    }

    public void UpdateScore()
    {
        int currentScore = PlayerPrefs.GetInt("current_score", 0);

        scoreText.text = "Skor: " + currentScore;
    }

}
