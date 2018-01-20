using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class pusher : NetworkBehaviour {

    public float push = 10;
    public float existingTime = 1;
    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= existingTime)
        {
            currentTime = 0;
            Destroy(gameObject);
        }
    }

	void OnTriggerEnter(Collider col)
    {
        col.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * push);
    }
}
