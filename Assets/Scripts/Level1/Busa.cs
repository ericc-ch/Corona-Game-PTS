using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busa : MonoBehaviour
{
    public float minDieTime = 3,
        maxDieTime = 5;

    void Start()
    {
        StartCoroutine(WaitTilDie());
    }

    IEnumerator WaitTilDie()
    {
        float dieTime = Random.Range(minDieTime, maxDieTime);

        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }
}
