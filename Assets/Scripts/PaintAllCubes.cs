using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintAllCubes : MonoBehaviour
{

    public Renderer[] rendererArray;
    // Start is called before the first frame update
    void OnEnable()
    {
        rendererArray = GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            foreach (Renderer x in rendererArray)
            {
                Material otherMat = other.GetComponent<Renderer>().material;
                x.material = otherMat;
            }
        }
    }


}
