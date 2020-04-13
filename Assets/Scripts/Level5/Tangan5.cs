using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tangan5 : MonoBehaviour
{
    Vector2 defaultPos;
    Rigidbody2D rb;
    Transform target;

    void Start()
    {
        defaultPos = transform.localPosition;
        rb = GetComponent<Rigidbody2D>();

        target = transform.parent.GetChild(1).transform;
    }

    void Update()
    {
        if (transform.localPosition.x < target.localPosition.x)
        {
            transform.Translate(new Vector2(0.5f, 0f) * TimeManager.deltaTime * TimeManager.timeScale * ScoringSystem.difficulty);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (transform.localPosition.x >= defaultPos.x)
                {
                    transform.Translate(new Vector2(-0.2f, 0f), Space.Self);
                }
            }
        }
    }

    void OnTriggerEnter2D()
    {
        GlobalEvent.current.LevelEnd(false, 0);
    }
}
