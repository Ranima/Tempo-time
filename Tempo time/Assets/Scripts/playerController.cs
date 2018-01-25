using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerController : NetworkBehaviour {

    public float forceMultiplier = 5;
    public Vector3 velocity = Vector3.zero;
    public float jumpForce = 20;
    public float attackDuration = 1;
    public float maxVelocity = 1;
    private bool canAttack = true;
    public bool hasJumped = false;
    public GameObject pusher;
    private float attackTime = 0;

	void Update () {
		if(!isLocalPlayer)
        { return; }

        //////////Movement**************************************
        float x = Input.GetAxis("Horizontal") * forceMultiplier;
        float y = Input.GetAxis("Vertical") * forceMultiplier;

        GetComponent<Rigidbody>().maxAngularVelocity = maxVelocity;
        if (GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
        { transform.LookAt(GetComponent<Rigidbody>().velocity + transform.position - new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0)); }
        GetComponent<Rigidbody>().AddForce(x,0,y);

        velocity = GetComponent<Rigidbody>().velocity;

        if (Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            GetComponent<Rigidbody>().AddForce(0,jumpForce,0);
            hasJumped = true;
        }
        //////////////////////////////////////////////////////////////////////

        //////////Attacking******************************************
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            Instantiate(pusher, transform.position + (transform.forward * 1.1f), transform.rotation, transform);
            canAttack = false;
        }
        //////////////////////////////////////////////////////////////////////

        //////////AttackTimer**********************************************
        if(canAttack == false)
        {
            attackTime += Time.deltaTime;
            if(attackTime >= attackDuration)
            {
                canAttack = true;
                attackTime = 0;
            }
        }
        //////////////////////////////////////////////////////////////////
	}

    void OnCollisionEnter()
    {
            hasJumped = false;
    }
}
