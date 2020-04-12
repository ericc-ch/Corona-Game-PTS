using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelTimer : MonoBehaviour
{
    public float maxTime = 3f;

    Text text;

    float time;
    int currentLives;
    void Start()
    {
        text = GetComponent<Text>();

        currentLives = PlayerPrefs.GetInt("current_lives", 0);
        time = maxTime;
    }

    void Update()
    {
        if (currentLives > 0)
        {
            text.text = "Next Level in.. " + Mathf.RoundToInt(time).ToString();

            if (time > 1f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 1f;
            }
        }
    }
}
