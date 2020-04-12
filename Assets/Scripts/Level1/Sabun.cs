using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabun : MonoBehaviour
{
    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = mainCam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                transform.position = touchPos;
            }
        }
    }
}
