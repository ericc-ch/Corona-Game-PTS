using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kendaraan : MonoBehaviour
{
    Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit2D = Physics2D.Raycast(touchPos, Vector2.zero);

                if (hit2D.collider == col)
                {
                    if (col.CompareTag("04_mobil"))
                    {
                        GlobalEvent.current.LevelEnd(true, 100 + Mathf.RoundToInt(Timer.current.timeLeft));
                    }
                    else
                    {
                        GlobalEvent.current.LevelEnd(false, 0);
                    }
                }
            }
        }
    }
}
