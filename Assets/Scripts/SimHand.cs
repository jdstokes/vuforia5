using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHand : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float tiltSpeed = 5.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime* moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime* moveSpeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime* moveSpeed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime* moveSpeed);

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.up * Time.deltaTime* moveSpeed);

        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.down * Time.deltaTime* moveSpeed);

        }

        // rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X")* Time.deltaTime*tiltSpeed,Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * tiltSpeed,Space.World);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * tiltSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * tiltSpeed * Time.deltaTime);
        }


    }
}
