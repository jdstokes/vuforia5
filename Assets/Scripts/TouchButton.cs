using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform upEmpty;
    public Transform downEmpty;
    public Transform buttonMesh;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonMesh.position = downEmpty.position;
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("button pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonMesh.position = upEmpty.position;
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
