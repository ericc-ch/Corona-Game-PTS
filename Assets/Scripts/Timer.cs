using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer current;
    public float maxTime { get; set; } = 7f;
    public float timeLeft { get; set; }
    public bool loseOnTimeUp { get; set; } = true;
      
    Slider slider;

    float time;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        maxTime *= ScoringSystem.difficulty;
        time = maxTime + 0.5f;
        slider = GetComponent<Slider>();

        slider.value = 1f;

        if (loseOnTimeUp)
        {
            slider.onValueChanged.AddListener(WaktuHabis);
        }
        else
        {
            slider.onValueChanged.AddListener(WaktuHabisMenang);
        }
    }

    void Update()
    {
        time -= TimeManager.deltaTime;
        float value = time / maxTime;

        if (value < 1)
        {
            slider.value = value;

            timeLeft = value * maxTime;
        }
    }

    public void WaktuHabis(float value)
    {
        if (value <= 0)
        {
            GlobalEvent.current.LevelEnd(false, 0);
        }
    }

    public void WaktuHabisMenang(float value)
    {
        if (value <= 0)
        {
            GlobalEvent.current.LevelEnd(true, 100);
        }
    }
}
