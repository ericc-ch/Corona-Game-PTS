using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public GameObject virus;
    public Transform[] tangan;
    public float spawnTime = 2f;

    public static VirusSpawner current;

    Camera mainCamera;
    int screenWidth,
        screenHeight;

    void Start()
    {
        current = this;

        mainCamera = Camera.main;
        screenWidth = mainCamera.scaledPixelWidth;
        screenHeight = mainCamera.scaledPixelHeight;

        StartCoroutine(SpawnVirus());
    }

    IEnumerator SpawnVirus()
    {
        while (true)
        {
            Transform preferredHand = tangan[Random.Range(0, 2)];
            Vector3 spawnLocation = RandomPos();

            GameObject localVirus = Instantiate(virus, spawnLocation, Quaternion.identity);

            TargetJoint2D targetJoint = localVirus.GetComponent<TargetJoint2D>();
            targetJoint.autoConfigureTarget = false;
            targetJoint.target = preferredHand.position;
            targetJoint.maxForce = 20;

            while (TimeManager.isPaused)
            {
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(spawnTime / TimeManager.timeScale);
        }

    }

    Vector3 RandomPos()
    {
        float[] xs = new float[]
        {
            Random.Range(-25f, -10f),
            Random.Range(screenWidth + 10f, screenWidth + 25f),
        };
        float[] ys = new float[]
        {
            Random.Range(-25f, -10f),
            Random.Range(screenHeight + 10f, screenHeight + 25f),
        };

        Vector3 position =  mainCamera.ScreenToWorldPoint(new Vector3(xs[Random.Range(0, 2)], ys[Random.Range(0, 2)], 0));
        position.z = 0;

        return position;
    }
}
