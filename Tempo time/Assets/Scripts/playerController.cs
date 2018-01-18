using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerController : NetworkBehaviour {

    public float forceMultiplier = 5;

	void Update () {
		if(!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * forceMultiplier;
        float y = Input.GetAxis("Vertical") * forceMultiplier;

        if(GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
        transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position);
        GetComponent<Rigidbody>().AddForce(x,0,y);

        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
	}

    void Collision()
    {

    }
}
