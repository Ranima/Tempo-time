using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterController : MonoBehaviour {

    public float forceMultiplier = 10;
    public float rotSpeed = 10;
    Quaternion oldvar;
    Quaternion newvar;


    void Update ()
    {
        float x = Input.GetAxis("Horizontal") * forceMultiplier;
        float y = Input.GetAxis("Vertical") * forceMultiplier;

        if (GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
        {
            oldvar = transform.rotation;
            transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0));
            newvar = transform.rotation;
            transform.rotation = Quaternion.Lerp(oldvar, newvar, rotSpeed);
            //transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0));
        }
        GetComponent<Rigidbody>().AddForce(x, 0, y);
    }
}
