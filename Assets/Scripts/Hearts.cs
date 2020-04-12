using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject[] hearts;

    Animator animator;

    int currentLives;
    void Awake()
    {
        currentLives = PlayerPrefs.GetInt("current_lives", 3);

        //BUKAN SAFE SOLUTION BUT GUA UDAH MAGER JADI BODO AMAT
        //HARUSNYA FOREACH LIFE INSTANTIATE TAPI NANTI NGEREFER KE PARENT SUSAH LAGI
        //UDAH LAH YA GINI AJA ANJIR MAGER
        if (currentLives < 3)
        {
            for (int i = 2; i > currentLives; i--)
            {
                Destroy(hearts[i]);
            }
        }

    }

    public void UpdateHearts()
    {
        animator = GetComponent<Animator>();
        currentLives = PlayerPrefs.GetInt("current_lives", 3);

        animator.SetInteger("heartsLeft", currentLives);

        if (currentLives < 3)
        {
            StartCoroutine(WaitAndDestroy(currentLives));
        }
    }

    IEnumerator WaitAndDestroy(int heartIndex)
    {
        yield return new WaitForSeconds(0.5f);

        if (heartIndex != 0)
        {
            Destroy(hearts[heartIndex]);
        }
        
    }
}
