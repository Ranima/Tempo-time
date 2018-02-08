using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfTrueing : MonoBehaviour {

    public bool isStanding = true;
    public float rot;
    public float rotationCheck;
    private Rigidbody rigid;

    void Start () {
        rigid = GetComponent<Rigidbody>();
    }

	void Update () {
        if (isStanding)
        {
            if (transform.rotation.x != 0)
            {
                rigid.AddTorque(rot, 0, 0);
            }
            if (transform.rotation.z != 0)
            {
                rigid.AddTorque(0, 0, rot);
            }
        }
	}
}
