using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float startHealth = 60;
    public float damage = 7;
    public float healingPower = 5;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = startHealth;
    }

    public void TakeDamage()
    {
        slider.value -= damage;
    }

    public void Heal()
    {
        slider.value += healingPower;
    }

    public void CekSkor()
    {
        if (slider.value <= 0)
        {
            GlobalEvent.current.LevelEnd(false, Mathf.RoundToInt(slider.value));
        }
        else if (slider.value >= 100)
        {
            GlobalEvent.current.LevelEnd(true, Mathf.RoundToInt(slider.value));
        }
    }
}
