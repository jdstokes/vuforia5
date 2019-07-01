using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDestructible : MonoBehaviour
{
    public GameObject Destructible;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if(other.tag == "Projectile")
        {
            Destructible.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
