using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour {

    public float lifetime = 1;
	void Update () {
        if (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
	}
}
