using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGM : MonoBehaviour
{
    void Awake()
    {
        Destroy(GameObject.FindGameObjectWithTag("gameplay_bgm"));

        GameObject[] menu_bgms = GameObject.FindGameObjectsWithTag("menu_bgm");

        if (menu_bgms.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
