using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardPen : MonoBehaviour
{
    private GameObject pen;
    public Whiteboard whiteboard;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;

    // Start is called before the first frame update
    void Start()
    {
        whiteboard = GameObject.FindObjectsOfType<Whiteboard>().First();
        pen = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float tipHeight = transform.localScale.y;
        
        if (Physics.Raycast(transform.position, transform.up, out touch, tipHeight) && touch.collider.GetComponent<Whiteboard>() != null)
        {
            // whiteboard = touch.collider.GetComponent<Whiteboard>();
            // Debug.Log("Touching");
            
            whiteboard = touch.collider.GetComponent<Whiteboard>();
            whiteboard.SetColor(Color.gray);
            whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            whiteboard.Touching = true;

            if (!lastTouch)
            {
                lastTouch = true;
                lastAngle = transform.rotation;
                Debug.Log(lastAngle);
            }
        }
        else 
        {
            whiteboard.Touching = false;
            lastTouch = false;
        }

        if (lastTouch)
        {
            pen.transform.rotation = lastAngle;
        }
    }
}
