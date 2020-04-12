using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OrangLepas : UnityEvent<int> { }
public class Level3Event : MonoBehaviour
{
    public static Level3Event current;

    public OrangLepas onOrangLepas;

    void Awake()
    {
        current = this;

        Timer.current.loseOnTimeUp = false;
    }

    public void OrangLepas(int idOrang)
    {
        onOrangLepas?.Invoke(idOrang);
    }
}
