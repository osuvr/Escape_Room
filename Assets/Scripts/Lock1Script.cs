using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock1Script : MonoBehaviour {

    public static bool havekey1;
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
        if (inTrigger && havekey1)
        {
            Destroy(this.gameObject);
            DoorScript.doorKey1 = true;
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Lock 1 is unlocked");
        }
    }
}
