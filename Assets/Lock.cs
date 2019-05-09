using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    public GameObject Key;
    public Vector3 KeyAnimationPosition;
    private Collider keyCollider;

    private Animator keyAnimator;

    private bool keyEntered = false;

    public UnityEvent OnKeyEntered;

    // Start is called before the first frame update
    void Start()
    {
        keyCollider = Key.GetComponent<Collider>();
        keyAnimator = Key.GetComponent<Animator>();
        keyAnimator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == Key.GetInstanceID())
        {
            keyEntered = true;
            Key.transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
            Key.GetComponent<Rigidbody>().isKinematic = true;
            // Key.transform.Translate()
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyEntered) 
        {
            if (Vector3.Distance(Key.transform.position, KeyAnimationPosition) > 0.1f)
            {
                Key.transform.position = Vector3.Lerp(Key.transform.position, KeyAnimationPosition, 0.75f);
            }
            else
            {
                keyEntered = false;
                keyAnimator.enabled = true;
                if (OnKeyEntered != null)
                    OnKeyEntered.Invoke();
                Destroy(Key, keyAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
