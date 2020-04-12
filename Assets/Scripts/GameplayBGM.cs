using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBGM : MonoBehaviour
{
    void Awake()
    {
        Destroy(GameObject.FindGameObjectWithTag("menu_bgm"));

        GameObject[] menu_bgms = GameObject.FindGameObjectsWithTag("gameplay_bgm");

        if (menu_bgms.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
