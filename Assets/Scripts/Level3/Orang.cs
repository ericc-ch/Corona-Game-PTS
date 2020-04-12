using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orang : MonoBehaviour
{
    public Slider health;

    Collider2D col,
        rumahCol;
    Camera mainCam;

    public int id;

    public float fullHealth = 7;
    Vector2 defaultPos;
    bool isHeld,
        alreadyInvoking;
    float maxTime = 1f,
        timeRemains;
    void Start()
    {
        GlobalEvent.current.onLevelEnd.AddListener(InvokedCheck);

        health.value = fullHealth;
        col = GetComponent<Collider2D>();
        rumahCol = transform.parent.GetChild(0).GetComponent<Collider2D>();

        defaultPos = transform.position;
        mainCam = Camera.main;
        timeRemains = maxTime;
    }

    void Update()
    {
        if (timeRemains > 0)
        {
            timeRemains = (timeRemains - TimeManager.deltaTime) / ScoringSystem.difficulty;
        }
        else
        {
            health.value -= 1;

            timeRemains = maxTime;
        }

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

                if (Physics2D.IsTouching(col, rumahCol))
                {
                    Level3Event.current.OrangLepas(id);
                }

                transform.position = defaultPos;
            }
        }
    }

    public void HealthCheck()
    {
        if (!alreadyInvoking)
        {
            if (health.value == 0)
            {
                GlobalEvent.current.LevelEnd(false, 0);
            }
        }
    }

    public void InvokedCheck(bool arg1, int arg2)
    {
        alreadyInvoking = true;
    }
}
