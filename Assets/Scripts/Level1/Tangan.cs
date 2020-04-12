using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tangan : MonoBehaviour
{
    public int id;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("virus"))
        {
            Destroy(col.gameObject);
            Level1Event.current.VirusHit(id);
        }
    }
        
    public void ChangeColor(int idTangan)
    {
        if (idTangan == id)
        {
            StartCoroutine(ChangeColorCoroutine());
        }
    }

    IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = new Color(1f, 194f/255f, 194f/255f);

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
