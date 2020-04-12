using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahiLalats : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;

    bool isVitC = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isVitC = col.CompareTag("02_vitc") ? true : false;
        Debug.Log(isVitC);
    }

    public void CekMenang()
    {
        if (isVitC)
        {
            GlobalEvent.current.LevelEnd(true, 100);
        }
        else
        {
            GlobalEvent.current.LevelEnd(false, 0);
        }

        ChangeSprite(isVitC);
    }

    public void ChangeSprite(bool isAlive)
    {
        spriteRenderer.sprite = isAlive ? sprites[1] : sprites[0];
    }
}
