using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class BotolParent : MonoBehaviour
{
    Vector2[] lokasiBotol;

    void Awake()
    {
        lokasiBotol = new Vector2[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            lokasiBotol[i] = transform.GetChild(i).position;
        }

        lokasiBotol.Shuffle();

        for (int i = 0; i < lokasiBotol.Length; i++)
        {
            transform.GetChild(i).position = lokasiBotol[i];
        }
    }
}
