using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botol : MonoBehaviour
{
    public Collider2D tahiLalatsCol;

    Camera mainCam;
    Vector2 defaultPos;
    Collider2D col;

    bool isHeld = false;

    void Start()
    {
        mainCam = Camera.main;
        defaultPos = transform.position;

        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = mainCam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit2D = Physics2D.Raycast(touchPos, Vector2.zero);

                if (hit2D.collider == col)
                {
                    transform.position = touchPos;
                    isHeld = true;
                }
            }

            if (touch.phase == TouchPhase.Moved && isHeld)
            {
                transform.position = touchPos;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isHeld = false;

                if (Physics2D.IsTouching(col, tahiLalatsCol))
                {
                    Level2Event.current.BotolLepas();
                }

                transform.position = defaultPos;
            }
        }
    }
}
