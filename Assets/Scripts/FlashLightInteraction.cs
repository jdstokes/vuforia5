using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightInteraction : MonoBehaviour
{
    public Light myLight;

    void Interact()
    {
        myLight.enabled = !myLight.enabled;
    }

    void StopInteraction()
    {
    }
}
