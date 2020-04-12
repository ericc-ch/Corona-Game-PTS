using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class VirusHit : UnityEvent<int> { };


public class Level1Event : MonoBehaviour
{
    public VirusHit onVirusHit;
    public UnityEvent onSoapSoap;

    public static Level1Event current;

    void Awake()
    {
        current = this;
    }

    public void VirusHit(int idTangan)
    {
        onVirusHit?.Invoke(idTangan);
    }

    public void SoapSoap()
    {
        onSoapSoap?.Invoke();
    }

}
