using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefabPaintball;

    public Transform spawnPoint;

    public float shootForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject paintball =  Instantiate(prefabPaintball, spawnPoint.position, spawnPoint.rotation);
           paintball.GetComponent<Rigidbody>().AddForce(paintball.transform.forward * shootForce);
            Destroy(paintball, 4);
        }
    }
}
