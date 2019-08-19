using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator anim;
    private GameObject collidingObject;
    private GameObject heldObject;

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Debug.Log("Trigger entered");
            collidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited");
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("isGrabbing", true);

            if (collidingObject)
            {
                Grab();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("isGrabbing", false);
            if (heldObject)
            {
                Release();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (heldObject)
            {
                heldObject.BroadcastMessage("Interact");
            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (heldObject)
            {
                heldObject.BroadcastMessage("StopInteraction");
            }
        }
        
    }

    void Grab()
    {
        Debug.Log("Grab");
        heldObject = collidingObject;
        heldObject.transform.SetParent(transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Release()
    {
        Debug.Log("Release");

        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
