using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LevelEnd : UnityEvent<bool, int> { };

public class GlobalEvent : MonoBehaviour
{
    public LevelEnd onLevelEnd;
    public UnityEvent onGameEnd;

    public static GlobalEvent current;

    void Awake()
    {
        current = this;
    }

    public void LevelEnd(bool result, int score)
    {
        onLevelEnd?.Invoke(result, score);
    }

    public void GameEnd()
    {
        onGameEnd?.Invoke();
    }
}
