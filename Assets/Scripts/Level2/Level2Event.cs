using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level2Event : MonoBehaviour
{
    public UnityEvent onBotolLepas;

    public static Level2Event current;

    void Awake()
    {
        current = this;
    }

    public void BotolLepas()
    {
        onBotolLepas?.Invoke();
    }
}
