using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject endPanel;

    void Update()
    {
        if (!endPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pausePanel.activeInHierarchy)
                {
                    pausePanel.SetActive(false);
                    TimeManager.localTimeScale = 1f;
                }
                else
                {
                    pausePanel.SetActive(true);
                    TimeManager.localTimeScale = 0f;
                }
            }
        }
    }
}
