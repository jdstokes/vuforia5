using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteraction : MonoBehaviour
{
    public GameObject prefabPaintball;

    public Transform spawnPoint;

    public float shootForce;


    void Interact()
    {
        GameObject paintball = Instantiate(prefabPaintball, spawnPoint.position, spawnPoint.rotation);
        paintball.GetComponent<Rigidbody>().AddForce(paintball.transform.forward * shootForce);
        Destroy(paintball, 4);
    }

    void StopInteraction()
    {
    }

}
