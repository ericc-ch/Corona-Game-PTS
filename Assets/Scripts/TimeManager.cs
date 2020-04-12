using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static float localTimeScale { get; set; } = 1f;
    public static bool isPaused 
    {
        get
        {
            if (localTimeScale > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public static float deltaTime
    {
        get
        {
            return Time.deltaTime * localTimeScale;
        }
    }
    public static float timeScale
    {
        get
        {
            return Time.timeScale * localTimeScale;
        }
    }
}
