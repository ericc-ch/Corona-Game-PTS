using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class Pilihan : MonoBehaviour
{
    Vector2[] lokasi;

    void Awake()
    {
        lokasi = new Vector2[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            lokasi[i] = transform.GetChild(i).position;
        }

        lokasi.Shuffle();

        for (int i = 0; i < lokasi.Length; i++)
        {
            transform.GetChild(i).position = lokasi[i];
        }
    }
}
