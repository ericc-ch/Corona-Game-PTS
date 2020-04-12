using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Manager : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(Timer.current);
        Timer.current.loseOnTimeUp = false;
    }
}
