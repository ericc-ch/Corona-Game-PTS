using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanganParent : MonoBehaviour
{
    public GameObject bubble;

    Vector2 lastPos;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("sabun"))
        {
            Vector2 currentPos = col.transform.position;

            float distance = Vector2.Distance(currentPos, lastPos);

            if (distance / TimeManager.deltaTime >= 20)
            {
                Level1Event.current.SoapSoap();
            }

            lastPos = col.transform.position;
        }
    }

    public void SpawnBubbles()
    {
        if (Random.Range(1, 11) <= 4)
        {
            float minX = transform.position.x - 1.75f;
            float minY = transform.position.y - 1.2f;
            float maxX = transform.position.x + 1.75f;
            float maxY = transform.position.y + 1f;

            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            Instantiate(bubble, spawnPos, Quaternion.identity);
        }
    }
}
