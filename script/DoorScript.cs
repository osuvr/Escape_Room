using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public static bool doorKey1;
    public static bool doorKey2;
    public bool open;
    public bool close;
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
            if(close)
            {
                if(doorKey1 && doorKey2)
                {
                        open = true;
                        close = false;
                }
            }
            else
            {
                    close = true;
                    open = false;
            }
        }

        if (open)
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }
        else
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }
    }

    void OnGUI()
    {
        if(inTrigger)
        {
            if(open)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "You win the game!");
            }
            else
            {
                if(doorKey1 && doorKey2)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Door is opening");
                }
                else if(doorKey1)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a key 2");
                }
                else if(doorKey2)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a key 1");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need all key");
                }
            }
        }
    }

}
