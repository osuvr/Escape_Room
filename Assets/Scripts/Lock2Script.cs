using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock2Script : MonoBehaviour {

    public static bool havekey2;
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
        if (inTrigger && havekey2)
        {
            Destroy(this.gameObject);
            DoorScript.doorKey2 = true;
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Lock 2 is unlocked");
        }
    }
}
