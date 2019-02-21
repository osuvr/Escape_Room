using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey1 : MonoBehaviour {

    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if(inTrigger)
        {
            Lock1Script.havekey1 = true;
        }
    }

    void OnGUI()
    {
        if(inTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Key 1");
        }
    }
}
