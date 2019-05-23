using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspendible : MonoBehaviour
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Suspend()
    {
        rigidbody.isKinematic = true;
    }

    public void Unsuspend()
    {
        rigidbody.isKinematic = false;
    }
}
