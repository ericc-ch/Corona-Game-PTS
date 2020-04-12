using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumah : MonoBehaviour
{
    public int id;

    Collider2D col,
        orangCol;
    SpriteRenderer stroke;

    Color newColor;
    bool isRumahnyaBener = false;
    void Start()
    {
        Level3Event.current.onOrangLepas.AddListener(CekOrang);

        col = GetComponent<Collider2D>();
        orangCol = transform.parent.GetChild(1).GetComponent<Collider2D>();
        stroke = transform.GetChild(1).GetComponent<SpriteRenderer>();

        newColor = stroke.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isRumahnyaBener = col == orangCol ? true : false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        SetAlpha(1f);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        SetAlpha(0f);
    }

    void SetAlpha(float alpha)
    {
        newColor.a = alpha;
        stroke.color = newColor;
    }

    public void CekOrang (int id)
    {
        if (this.id == id)
        {
            orangCol.gameObject.SetActive(false);

            StartCoroutine(PutBack());
        }
    }

    IEnumerator PutBack()
    {
        float randomTime = (Random.Range(3f, 7f) / ScoringSystem.difficulty) / TimeManager.timeScale;

        yield return new WaitForSeconds(randomTime);

        orangCol.gameObject.SetActive(true);
    }
}
