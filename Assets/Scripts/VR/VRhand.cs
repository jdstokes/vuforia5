using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRhand : MonoBehaviour
{
    public Animator anim;
    private GameObject collidingObject;
    private GameObject heldObject;

    public bool isLeftHand;
    private string grip;
    private bool gripHeld;
    private string trigger;
    private bool triggerHeld;
    #region Input mapping

    void Start()
    {
        if (isLeftHand)
        {
            grip = "Left Grip";
            trigger = "Left Trigger";
        }
        else
        {
            grip = "Right Grip";
            trigger = "Right Trigger";
        }
    }

    void Update()
    {
        // An example of creating a flag
        if (Input.GetAxis(grip) > 0.5f && !gripHeld)
        {
            gripHeld = true;

            anim.SetBool("isGrabbing", true);

            if (collidingObject)
            {
                Grab();
            }

        }
        else if (Input.GetAxis(grip) < 0.5f && gripHeld)
        {
            gripHeld = false;

            anim.SetBool("isGrabbing", false);
            if (heldObject)
            {
                Release();
            }
        }

        if (Input.GetAxis(trigger) > 0.5f && !triggerHeld)
        {
            triggerHeld = true;
            if (heldObject)
            {
                heldObject.BroadcastMessage("Interact");
            }
        }
        else if(Input.GetAxis(trigger) < 0.5f && triggerHeld)
        {
            triggerHeld = false;
            if (heldObject)
            {
                heldObject.BroadcastMessage("StopInteraction");
            }

        }
    }

    #endregion

    void Grab()
    {
        heldObject = collidingObject;
        heldObject.transform.SetParent(transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Release()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            collidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }


   
}
