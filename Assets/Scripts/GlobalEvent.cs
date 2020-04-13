using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LevelEnd : UnityEvent<bool, int> { };
[System.Serializable]
public class LateLevelEnd : UnityEvent<bool, int> { };

public class GlobalEvent : MonoBehaviour
{
    public LevelEnd onLevelEnd;
    public LateLevelEnd lateLevelEnd;

    public static GlobalEvent current;

    void Awake()
    {
        current = this;
    }

    public void LevelEnd(bool result, int Addedscore)
    {
        onLevelEnd?.Invoke(result, Addedscore);
    }

    public void LateLevelEnd(bool result, int AddedScore)
    {
        lateLevelEnd?.Invoke(result, AddedScore);
    }
}
