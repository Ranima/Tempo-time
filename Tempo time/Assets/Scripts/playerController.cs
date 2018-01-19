using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerController : NetworkBehaviour {

    public float forceMultiplier = 5;
    public float jumpForce = 20;
    public float push = 10;
    public bool hasJumped = false;

	void Update () {
		if(!isLocalPlayer)
        {
            return;
        }

        //////////Movement**************************************
        float x = Input.GetAxis("Horizontal") * forceMultiplier;
        float y = Input.GetAxis("Vertical") * forceMultiplier;

        if(GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
        transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0));
        GetComponent<Rigidbody>().AddForce(x,0,y);

        if(Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            GetComponent<Rigidbody>().AddForce(0,jumpForce,0);
            hasJumped = true;
        }
        //////////////////////////////////////////////////////////////////////

        //////////Pushing******************************************
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddExplosionForce(push, transform.position + GetComponent<Rigidbody>().velocity.normalized, 1);
        }
        //////////////////////////////////////////////////////////////////////
	}

    void OnCollisionEnter()
    {
            hasJumped = false;
    }
}
