using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecheck : MonoBehaviour {
    public Material mat;
    Transform colorTrget;
    Renderer ren;


	// Use this for initialization
	void Start () {
        ren = GetComponent<Renderer>();
        ren.enabled = true;
        ren.sharedMaterial = mat;
	}
	
	// Update is called once per frame
	void Update () {

        


		
	}
}
