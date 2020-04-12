using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    void Awake()
    {
        ScoringSystem.current.Clear();
    }
}
