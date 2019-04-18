using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject Key;
    private Collider keyCollider;

    // Start is called before the first frame update
    void Start()
    {
        keyCollider = Key.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == Key.GetInstanceID())
        {
            Debug.Log("Key entered");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
