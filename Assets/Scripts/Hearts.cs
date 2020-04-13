using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject heart;

    public float xOffset = 224f;

    Animator animator;

    int currentLives;
    void Awake()
    {
        currentLives = PlayerPrefs.GetInt("current_lives", 3);
    }

    public void UpdateHearts(bool result, int addedScore)
    {
        currentLives = PlayerPrefs.GetInt("current_lives", 3);

        if (result)
        {
            ShowHearts(currentLives);
        }
        else
        {
            GameObject[] hearts = new GameObject[currentLives + 1];

            ShowHearts(currentLives + 1);

            Debug.Log("hai aku childcount : " + transform.childCount);

            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log("hai aku index : " + i);

                hearts[i] = transform.GetChild(i).gameObject;
            }

            StartCoroutine(Die(hearts[currentLives], transform));
        }
    }

    void ShowHearts(int count)
    {
        RectTransform heartRect = heart.GetComponent<RectTransform>();

        Vector2 pos = heartRect.anchoredPosition;

        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(heart, transform);
            temp.GetComponent<RectTransform>().anchoredPosition = pos;

            pos.x += xOffset;
        }
    }

    IEnumerator Die(GameObject heart, Transform hearts)
    {
        RectTransform rect = heart.GetComponent<RectTransform>();

        heart.transform.SetParent(hearts.parent);

        Vector2 target = new Vector2(rect.position.x, rect.position.y + 500); 

        while (heart.transform.position.y < target.y)
        {
            heart.transform.Translate(Vector2.up);

            yield return new WaitForSeconds(0.008f);
        }

        Debug.Log("JALAN DONG :\")");
    }
}
